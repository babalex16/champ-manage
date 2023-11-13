using AutoMapper;
using ChampManage.API.Entities;
using ChampManage.API.Models;
using ChampManage.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChampManage.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ??
                throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ??
               throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        [HttpGet("{categoryId}", Name = "GetCategoryById")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);

            if (category == null)
            {
                return NotFound("Category not found.");
            }

            return Ok(_mapper.Map<CategoryDto>(category));
        }
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CategoryDto categoryCreateDto)
        {
            // Additional validation if needed
            if (categoryCreateDto == null)
            {
                return BadRequest("Invalid category data.");
            }

            var categoryEntity = _mapper.Map<Category>(categoryCreateDto);

            _categoryRepository.AddCategory(categoryEntity);

            if (!await _categoryRepository.SaveChangesAsync())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);

            return CreatedAtRoute("GetCategoryById", new { categoryId = categoryToReturn.Id }, categoryToReturn);
        }

        [HttpDelete("{categoryId}")]
        public async Task<ActionResult> DeleteCategory(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);

            if (category == null)
            {
                return NotFound("Category not found.");
            }

            _categoryRepository.DeleteCategory(category);

            if (!await _categoryRepository.SaveChangesAsync())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }
    }
}
