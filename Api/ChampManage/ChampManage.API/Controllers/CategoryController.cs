using AutoMapper;
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
    }

}
