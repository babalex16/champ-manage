using AutoMapper;
using ChampManage.API.Entities;
using ChampManage.API.Models;
using ChampManage.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChampManage.API.Controllers
{
    [Authorize(Policy = "AdminOrOrganizerOnly")]
    [Route("api/championships")]
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ChampionshipDto>> GetChampionships()
        {
            var championships = await _championshipRepository.GetChampionshipsAsync();
            var result = _mapper.Map<IEnumerable<ChampionshipDto>>(championships);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("{championshipId}", Name = "GetChampionship")]
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

        [HttpPost]
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

        [HttpDelete("{championshipId}")]
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

        [HttpPatch("{championshipId}")]
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

        [HttpPost("{championshipId}/addCategory/{categoryId}")]
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

        [HttpDelete("{championshipId}/removeCategory/{categoryId}")]
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

        [HttpGet("{championshipId}/getCategories", Name = "GetCategoriesForChampionship")]
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

        [HttpPost("{championshipId}/categories/registerUser")]
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


        [HttpGet("{championshipId}/categories/{categoryId}", Name = "GetRegisteredUsersForCategory")]
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

        [HttpDelete("{championshipId}/deregisterUser")]
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

        [HttpPost("{championshipId}/createMatches")]
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

        [AllowAnonymous]
        [HttpGet("{championshipId}/matches")]
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

        [HttpDelete("{championshipId}/deleteMatches")]
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


        // Helper method to calculate age
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
