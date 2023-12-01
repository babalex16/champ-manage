using AutoMapper;
using ChampManage.API.Entities;
using ChampManage.API.Models.CategoryModels;
using ChampManage.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ChampManage.API.Controllers
{
    /// <summary>
    /// Endpoints for adding, removing and getting categories.
    /// </summary>
    [Authorize(Policy = "AdminOnly")]
    [Route("api/categories")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
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

        /// <summary>
        /// Gets a list of categories.
        /// </summary>
        /// <returns>An ActionResult of type IEnumerable of CategoryDto.</returns>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        /// <summary>
        /// Gets a category by its ID.
        /// </summary>
        /// <param name="categoryId">The ID of the category.</param>
        /// <returns>An ActionResult of type CategoryDto.</returns>
        [AllowAnonymous]
        [HttpGet("{categoryId}", Name = "GetCategoryById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);

            if (category == null)
            {
                return NotFound("Category not found.");
            }

            return Ok(_mapper.Map<CategoryDto>(category));
        }

        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="categoryCreateDto">The data for the new category.</param>
        /// <returns>An ActionResult of type CategoryDto.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CategoryDto categoryCreateDto)
        {
            if (categoryCreateDto == null)
            {
                return BadRequest("Invalid category data.");
            }

            var categoryEntity = _mapper.Map<Category>(categoryCreateDto);

            _categoryRepository.AddCategory(categoryEntity);

            await _categoryRepository.SaveChangesAsync();

            var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);

            return CreatedAtRoute("GetCategoryById", new { categoryId = categoryToReturn.Id }, categoryToReturn);
        }

        /// <summary>
        /// Deletes a category by its ID.
        /// </summary>
        /// <param name="categoryId">The ID of the category to delete.</param>
        /// <returns>An ActionResult.</returns>
        [HttpDelete("{categoryId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteCategory(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);

            if (category == null)
            {
                return NotFound("Category not found.");
            }

            _categoryRepository.DeleteCategory(category);

            await _categoryRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
