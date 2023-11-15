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

        [HttpGet]
        public async Task<ActionResult<ChampionshipDto>> GetChampionships()
        {
            var championships = await _championshipRepository.GetChampionshipsAsync();
            var result = _mapper.Map<IEnumerable<ChampionshipDto>>(championships);
            return Ok(result);
        }

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
        [Authorize(Policy = "OrganizerOnly")]
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

            _championshipRepository.DeleteChampionship(championshipEntity);
            await _championshipRepository.SaveChangesAsync();

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

            if (_championshipRepository.CategoryExistsInChampionship(championshipId, categoryId))
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

            if (!_championshipRepository.CategoryExistsInChampionship(championshipId, categoryId))
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
            // Check if the championship and category exist
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

            var userCategoryRegistrations = await _userRepository.GetRegisteredUsersForCategory(championshipId, categoryId);

            var registeredUsers = new List<UserPublicDto>(); // Use UserPublicDto instead of User
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


    }
}
