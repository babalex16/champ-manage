using AutoMapper;
using ChampManage.API.Entities;
using ChampManage.API.Interfaces;
using ChampManage.API.Models.UserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ChampManage.API.Controllers
{
    /// <summary>
    /// API endpoints for managing user accounts.
    /// </summary>
    [Authorize(Policy = "RegisteredUserOnly")]
    [Route("api/users")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository,
                                IMapper mapper)
        {
            _userRepository = userRepository ??
                throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Gets a list of all users.
        /// </summary>  
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var userEntities = await _userRepository.GetUsersAsync();

            return Ok(_mapper.Map<IEnumerable<UserDto>>(userEntities));
        }

        /// <summary>
        /// Gets a user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        [HttpGet("{userId}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> GetUser(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserDto>(user));
        }

        /// <summary>
        /// Gets a user by their email.
        /// </summary>
        /// <param name="userEmailDto">The email of the user.</param>
        [HttpGet("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> GetUserByEmail([FromBody] UserEmailDto userEmailDto)
        {
            if (string.IsNullOrWhiteSpace(userEmailDto.Email))
            {
                return BadRequest("Email parameter is required.");
            }

            var user = await _userRepository.GetUserByEmailAsync(userEmailDto.Email);

            if (user == null)
            {
                return NotFound($"User with email '{userEmailDto.Email}' not found.");
            }

            return Ok(_mapper.Map<UserDto>(user));
        }

        /// <summary>
        /// Creates or updates a user's profile, which is mandatory for championship registration.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="patchDoc">The JSON patch document for updating the user's profile.</param>
        [HttpPatch("{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> CreateUserProfile(
                int userId,
                JsonPatchDocument<UserProfileCreationDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var existingUserEntity = await _userRepository.GetUserByIdAsync(userId);

            if (existingUserEntity == null)
            {
                return NotFound();
            }

            var userProfileDto = _mapper.Map<UserProfileCreationDto>(existingUserEntity);

            patchDoc.ApplyTo(userProfileDto, ModelState);

            if (!TryValidateModel(userProfileDto))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(userProfileDto, existingUserEntity);
            await _userRepository.SaveChangesAsync();

            return NoContent();
        }


        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int userId)
        {

            var userEntity = await _userRepository.GetUserByIdAsync(userId);

            if (userEntity == null)
            {
                return NotFound();
            }

            _userRepository.DeleteUser(userEntity);
            await _userRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Gives organizer rights to a user.
        /// </summary>
        /// <param name="organizerEmail">The email of the user to grant organizer rights.</param>
        [HttpPatch("giveOrganizerRights/{organizerEmail}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserDto>> GiveOrganizerRights(string organizerEmail)
        {
            if (organizerEmail == null || string.IsNullOrEmpty(organizerEmail))
            {
                return BadRequest("Invalid email data.");
            }

            var user = await _userRepository.GetUserByEmailAsync(organizerEmail);

            if (user == null)
            {
                return NotFound($"User with email '{organizerEmail}' not found.");
            }

            user.UserType = UserType.Organizer;
            await _userRepository.SaveChangesAsync();

            return Ok(_mapper.Map<UserDto>(user));
        }

        /// <summary>
        /// Revokes organizer rights from a user.
        /// </summary>
        /// <param name="organizerEmail">The email of the user to revoke organizer rights.</param>
        [HttpPatch("revokeOrganizerRights/{organizerEmail}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> RevokeOrganizerRights(string organizerEmail)
        {
            if (organizerEmail == null || string.IsNullOrEmpty(organizerEmail))
            {
                return BadRequest("Invalid email data.");
            }

            var user = await _userRepository.GetUserByEmailAsync(organizerEmail);

            if (user == null)
            {
                return NotFound($"User with email '{organizerEmail}' not found.");
            }

            user.UserType = UserType.Participant;
            await _userRepository.SaveChangesAsync();

            return Ok(_mapper.Map<UserDto>(user));
        }
    }
}
