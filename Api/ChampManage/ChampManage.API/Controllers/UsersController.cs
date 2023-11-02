using AutoMapper;
using ChampManage.API.Entities;
using ChampManage.API.Models;
using ChampManage.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ChampManage.API.Controllers
{
    [Route("api/users")]
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var userEntities = await _userRepository.GetUsersAsync();

            return Ok(_mapper.Map<IEnumerable<UserDto>>(userEntities));
        }

        [Authorize]
        [HttpGet("{userId}", Name = "GetUser")]
        public async Task<ActionResult<UserDto>> GetUser(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPatch("{userId}")]
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

        [HttpDelete("{userId}")]
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
    }
}
