using AutoMapper;
using ChampManage.API.Entities;
using ChampManage.API.Models;
using ChampManage.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ChampManage.API.Controllers
{
    [Route("api/championships")]
    [ApiController]
    public class ChampionshipsController : ControllerBase
    {
        private readonly IChampionshipRepository _championshipRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ChampionshipsController( IChampionshipRepository championshipRepository,
                                        ICategoryRepository categoryRepository, 
                                        IMapper mapper)
        {
            _championshipRepository = championshipRepository ??
                throw new ArgumentNullException(nameof(championshipRepository));
            _categoryRepository = categoryRepository ?? 
                throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetChampionships()
        {
            var championships = await _championshipRepository.GetChampionshipsAsync();
            var result = _mapper.Map<IEnumerable<ChampionshipDto>>(championships);
            return Ok(result);
        }

        [HttpGet("{championshipId}", Name = "GetChampionship")]
        public async Task<IActionResult> GetChampionship(int championshipId)
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
                new { championshipId = createdChampionshipDtoToReturn.Id },
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
        public IActionResult AddCategoryToChampionship(int championshipId, int categoryId)
        {
            if (!_categoryRepository.CategoryExists(categoryId))
            {
                return NotFound("Category not found.");
            }

            var championship = _championshipRepository.GetChampionshipByIdAsync(championshipId);

            if (championship == null )
            {
                return NotFound("Championship or Category not found.");
            }

            if (_championshipRepository.CategoryExistsInChampionship(championshipId, categoryId))
            {
                return Conflict("Category already exists for the specified Championship.");
            }

            _championshipRepository.AddCategoryToChampionship(championshipId, categoryId);

            return CreatedAtAction(nameof(AddCategoryToChampionship), 
                new { championshipId, categoryId }, 
                "Category added to championship successfully.");
        }


        [HttpGet("{championshipId}/getCategories")]
        public async Task<IActionResult> GetCategoriesForChampionship(int championshipId)
        {
            var categories = await _championshipRepository.GetCategoriesForChampionshipAsync(championshipId);

            if (categories == null || !categories.Any())
            {
                return NotFound("No categories found for the specified Championship.");
            }

            var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return Ok(categoryDtos);
        }

    }
}
