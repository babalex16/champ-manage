using AutoMapper;
using ChampManage.API.Entities;
using ChampManage.API.Models;
using ChampManage.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace ChampManage.API.Controllers
{
    /// <summary>
    /// API endpoints for managing championships.
    /// </summary>
    [Authorize(Policy = "AdminOrOrganizerOnly")]
    [Route("api/championships")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class ChampionshipsController : ControllerBase
    {
        private readonly IChampionshipRepository _championshipRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ChampionshipsController( IChampionshipRepository championshipRepository,
                                        ICategoryRepository categoryRepository, 
                                        IUserRepository userRepository,
                                        IMapper mapper)
        {
            _championshipRepository = championshipRepository ??
                throw new ArgumentNullException(nameof(championshipRepository));
            _categoryRepository = categoryRepository ?? 
                throw new ArgumentNullException(nameof(categoryRepository));
            _userRepository = userRepository ?? 
                throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Gets a list of championships.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ChampionshipDto>> GetChampionships()
        {
            var championships = await _championshipRepository.GetChampionshipsAsync();
            var result = _mapper.Map<IEnumerable<ChampionshipDto>>(championships);
            return Ok(result);
        }

        /// <summary>
        /// Gets a championship by its ID.
        /// </summary>
        /// <param name="championshipId">The ID of the championship.</param>
        [AllowAnonymous]
        [HttpGet("{championshipId}", Name = "GetChampionship")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ChampionshipDto>> GetChampionship(int championshipId)
        {
            var championship = await _championshipRepository.GetChampionshipByIdAsync(championshipId);

            if (championship == null)
            {
                return NotFound();
            }

            var championshipDto = _mapper.Map<ChampionshipDto>(championship);
            return Ok(championshipDto);
        }

        /// <summary>
        /// Creates a new championship.
        /// </summary>
        /// <param name="championshipForCreationDto">The data for the new championship.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ChampionshipDto>> CreateChampionship(
                ChampionshipForCreationDto championshipForCreationDto)
        {
            if (championshipForCreationDto == null)
            {
                return BadRequest();
            }

            var championshipToCreate = _mapper.Map<Championship>(championshipForCreationDto);

            _championshipRepository.CreateChampionship(championshipToCreate);
            await _championshipRepository.SaveChangesAsync();

            //TODO: add champ to User's CreatedChampionships collection

            var createdChampionshipDtoToReturn = _mapper.Map<ChampionshipDto>(championshipToCreate);

            return CreatedAtRoute("GetChampionship",
                new {
                    championshipId = createdChampionshipDtoToReturn.Id 
                },
                createdChampionshipDtoToReturn);
        }

        /// <summary>
        /// Deletes a championship by its id.
        /// </summary>
        /// <param name="championshipId">The ID of the championship to delete.</param>
        [HttpDelete("{championshipId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteChampionship(int championshipId)
        {

            var championshipEntity = await _championshipRepository.GetChampionshipByIdAsync(championshipId);

            if (championshipEntity == null)
            {
                return NotFound();
            }

            //TODO: check if provided OrganizerId is valid

            _championshipRepository.DeleteChampionship(championshipEntity);
            await _championshipRepository.SaveChangesAsync();

            //TODO: remove from User's CreatedChampionships collection

            return NoContent();
        }

        /// <summary>
        /// Partially updates a championship by its id and the provided patch document.
        /// </summary>
        /// <param name="championshipId">The id of the championship to update.</param>
        /// <param name="patchDoc">The patch document containing the updates to the championship.</param>
        [HttpPatch("{championshipId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PartiallyUpdateChampionship(
                int championshipId,
                JsonPatchDocument<ChampionshipForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var existingChampionshipEntity = await _championshipRepository.GetChampionshipByIdAsync(championshipId);

            if (existingChampionshipEntity == null)
            {
                return NotFound();
            }

            var championshipToPatch = _mapper.Map<ChampionshipForUpdateDto>(existingChampionshipEntity);

            patchDoc.ApplyTo(championshipToPatch, ModelState);

            if (!TryValidateModel(championshipToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(championshipToPatch, existingChampionshipEntity);
            await _championshipRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Adds a category to a championship.
        /// </summary>
        /// <param name="championshipId">The ID of the championship.</param>
        /// <param name="categoryId">The ID of the category to add.</param>
        [HttpPost("{championshipId}/addCategory/{categoryId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AddCategoryToChampionship(int championshipId, int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            if (category == null )
            {
                return NotFound("Category not found.");
            }

            var championship = await _championshipRepository.GetChampionshipByIdAsync(championshipId);
            if (championship == null )
            {
                return NotFound("Championship not found.");
            }

            if (await _championshipRepository.CategoryExistsInChampionshipAsync(championshipId, categoryId))
            {
                return Conflict("Category already exists for the specified Championship.");
            }

            _championshipRepository.AddCategoryToChampionship(championshipId, categoryId);
            await _championshipRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(AddCategoryToChampionship), 
                new { championshipId, categoryId }, 
                "Category added to championship successfully.");
        }

        /// <summary>
        /// Removes a category from a championship.
        /// </summary>
        /// <param name="championshipId">The ID of the championship.</param>
        /// <param name="categoryId">The ID of the category to remove.</param>
        [HttpDelete("{championshipId}/removeCategory/{categoryId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveCategoryFromChampionship(int championshipId, int categoryId)
        {
            var championship = await _championshipRepository.GetChampionshipByIdAsync(championshipId);
            if (championship == null)
            {
                return NotFound($"Championship with ID {championshipId} not found.");
            }

            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            if (category == null)
            {
                return NotFound($"Category with ID {categoryId} not found.");
            }

            var championshipCategory = championship.ChampionshipCategories
                .FirstOrDefault(cc => cc.CategoryId == categoryId);

            if (! await _championshipRepository.CategoryExistsInChampionshipAsync(championshipId, categoryId))
            {
                return NotFound("Category does not exist for the specified Championship.");
            }

            _championshipRepository.RemoveCategoryFromChampionship(championshipId, categoryId);
            await _championshipRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Gets the categories associated with a specific championship.
        /// </summary>
        /// <param name="championshipId">The id of the championship to get the categories for.</param>
        [HttpGet("{championshipId}/getCategories", Name = "GetCategoriesForChampionship")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategoriesForChampionship(int championshipId)
        {
            var championship = await _championshipRepository.GetChampionshipByIdAsync(championshipId);
            if (championship == null)
            {
                return NotFound($"Championship with ID {championshipId} not found.");
            }

            var categories = await _championshipRepository.GetCategoriesForChampionshipAsync(championshipId);
            if (categories == null)
            {
                return NotFound("No categories associated with the following championship");
            }
            var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return Ok(categoryDtos);
        }

        /// <summary>
        /// Registers a user for a specific category in a championship.
        /// </summary>
        /// <param name="championshipId">The id of the championship to register the user for a category.</param>
        /// <param name="userCategoryRegistrationDto">The user and category to register.</param>
        [HttpPost("{championshipId}/categories/registerUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> RegisterUserForCategory(
            int championshipId,
            [FromBody] UserCategoryRegistrationDto userCategoryRegistrationDto)
        {
            var user = await _userRepository.GetUserByIdAsync(userCategoryRegistrationDto.UserId);
            if (user == null)
            {
                return NotFound($"User with ID {userCategoryRegistrationDto.UserId} not found.");
            }

            var category = await _categoryRepository.GetCategoryByIdAsync(userCategoryRegistrationDto.CategoryId);
            if (category == null)
            {
                return NotFound($"Category with ID {userCategoryRegistrationDto.CategoryId} not found.");
            }

            var championship = await _championshipRepository.GetChampionshipByIdAsync(userCategoryRegistrationDto.ChampionshipId);
            if (championship == null)
            {
                return NotFound($"Championship with ID {userCategoryRegistrationDto.ChampionshipId} not found.");
            }

            if (await _userRepository.CategoryExistsForUserInChampionship(
                userCategoryRegistrationDto.UserId,
                userCategoryRegistrationDto.CategoryId,
                userCategoryRegistrationDto.ChampionshipId))
            {
                return Conflict("User is already registered for the specified category in the championship.");
            }

            _userRepository.RegisterUserForCategory(userCategoryRegistrationDto);

            // Note: don't add championship to RegisteredChampionships, it is already done

            await _userRepository.SaveChangesAsync();

            return CreatedAtRoute(
                routeName: "GetRegisteredUsersForCategory",
                routeValues: new
                {
                    championshipId = userCategoryRegistrationDto.ChampionshipId,
                    categoryId = userCategoryRegistrationDto.CategoryId,
                    userId = userCategoryRegistrationDto.UserId
                },
                value: "User successfully registered for the category in the championship.");
        }

        /// <summary>
        /// Gets the registered users for a specific category in a championship.
        /// </summary>
        /// <param name="championshipId">The id of the championship to get the registered users for a category.</param>
        /// <param name="categoryId">The id of the category to get the registered users for.</param>
        [HttpGet("{championshipId}/categories/{categoryId}", Name = "GetRegisteredUsersForCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetRegisteredUsersForCategory(int championshipId, int categoryId)
        {
            var championship = await _championshipRepository.GetChampionshipByIdAsync(championshipId);
            if (championship == null)
            {
                return NotFound($"Championship with ID {championshipId} not found.");
            }

            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            if (category == null)
            {
                return NotFound($"Category with ID {categoryId} not found.");
            }

            // Check if the category is registered for the championship
            var isCategoryRegistered = await _championshipRepository.CategoryExistsInChampionshipAsync(championshipId, categoryId);
            if (!isCategoryRegistered)
            {
                return BadRequest($"Category with ID {categoryId} is not registered for the championship.");
            }

            var userCategoryRegistrations = await _userRepository.GetRegisteredUsersForCategory(championshipId, categoryId);

            var registeredUsers = new List<UserPublicDto>(); 
            foreach (var userCategoryRegistration in userCategoryRegistrations)
            {
                var user = await _userRepository.GetUserByIdAsync(userCategoryRegistration.Id);
                if (user != null)
                {
                    var userPublicDto = _mapper.Map<UserPublicDto>(user);
                    registeredUsers.Add(userPublicDto);
                }
            }

            return Ok(registeredUsers);
        }

        /// <summary>
        /// Removes a user from a category in a championship.
        /// </summary>
        /// <param name="championshipId">The id of the championship to remove the user from a category.</param>
        /// <param name="userCategoryRegistrationDto">The user and category to remove.</param>
        [HttpDelete("{championshipId}/deregisterUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeregisterUserFromCategory(
                int championshipId, 
                [FromBody] UserCategoryRegistrationDto userCategoryRegistrationDto)
        {
            var championship = await _championshipRepository.GetChampionshipByIdAsync(championshipId);
            if (championship == null)
            {
                return NotFound($"Championship with ID {championshipId} not found.");
            }

            var category = await _categoryRepository.GetCategoryByIdAsync(userCategoryRegistrationDto.CategoryId);
            if (category == null)
            {
                return NotFound($"Category with ID {userCategoryRegistrationDto.CategoryId} not found.");
            }

            var user = await _userRepository.GetUserByIdAsync(userCategoryRegistrationDto.UserId);
            if (user == null)
            {
                return NotFound($"User with ID {userCategoryRegistrationDto.UserId} not found.");
            }

            // Check if the user is registered for the specified category in the championship
            var userCategoryRegistration = await _userRepository.GetUserCategoryRegistration(championshipId, userCategoryRegistrationDto.CategoryId, userCategoryRegistrationDto.UserId);
            if (userCategoryRegistration == null)
            {
                return NotFound("User is not registered for the specified category in the championship.");
            }

            _userRepository.DeregisterUserFromCategory(userCategoryRegistration);
            // Note: don't remove championship from RegisteredChampionships, it is already done

            await _userRepository.SaveChangesAsync();

            return NoContent(); 
        }

        /// <summary>
        /// Creates matches for all categories in a championship.
        /// </summary>
        /// <param name="championshipId">The id of the championship to create matches for.</param>
        [HttpPost("{championshipId}/createMatches")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateMatchesForChampionship(int championshipId)
        {
            var championship = await _championshipRepository.GetChampionshipByIdAsync(championshipId);
            if (championship == null)
            {
                return NotFound($"Championship with ID {championshipId} not found.");
            }

            var categories = await _championshipRepository.GetCategoriesForChampionshipAsync(championshipId);
            if (categories == null)
            {
                return NotFound("No categories associated with the following championship");
            }

            _categoryRepository.CreateMatchesForChampionship(championshipId);

            await _categoryRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Gets all matches for a championship.
        /// </summary>
        /// <param name="championshipId">The id of the championship to get matches for.</param>
        [AllowAnonymous]
        [HttpGet("{championshipId}/matches")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMatchesForChampionship(int championshipId)
        {
            var championship = await _championshipRepository.GetChampionshipByIdAsync(championshipId);
            if (championship == null)
            {
                return NotFound($"Championship with ID {championshipId} not found.");
            }

            var matches = _categoryRepository.GetMatchesForChampionship(championshipId)
                .Select(match => new MatchRetrievalDto
                {
                    // Category
                    CategoryName = _categoryRepository.GetCategoryNameByChampionshipCategoryId(match.ChampionshipCategoryId),
                    Order = match.Order,

                    // Participant1
                    Participant1FullName = GetFullName(match.Participant1),
                    Participant1TeamName = match.Participant1?.TeamName ?? string.Empty,
                    Participant1Age = CalculateAge(match.Participant1?.Birthdate),

                    // Participant2
                    Participant2FullName = GetFullName(match.Participant2),
                    Participant2TeamName = match.Participant2?.TeamName ?? string.Empty,
                    Participant2Age = CalculateAge(match.Participant2?.Birthdate),

                    // Winner
                    IsParticipant1Winner = match.IsParticipant1Winner,

                });

            return Ok(matches);
        }

        /// <summary>
        /// Deletes all matches for a championship.
        /// </summary>
        /// <param name="championshipId">The id of the championship to delete matches for.</param>
        [HttpDelete("{championshipId}/deleteMatches")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMatchesForChampionship(int championshipId)
        {
            var championship = await _championshipRepository.GetChampionshipByIdAsync(championshipId);
            if (championship == null)
            {
                return NotFound($"Championship with ID {championshipId} not found.");
            }

            // Call a method in your repository to delete matches for the given championshipId
            _categoryRepository.DeleteMatchesForChampionship(championshipId);

            await _categoryRepository.SaveChangesAsync();

            return NoContent();
        }


        // Helper method to calculate age  based on the provided birthdate.
        private static int? CalculateAge(DateTime? birthdate)
        {
            if (birthdate == null)
            {
                return null;
            }

            DateTime currentDate = DateTime.UtcNow;
            int age = currentDate.Year - birthdate.Value.Year;

            // Check if the birthday has occurred this year
            if (birthdate.Value.Date > currentDate.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        // Helper method to get full name
        private static string GetFullName(User? user)
        {
            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }
    }
}
