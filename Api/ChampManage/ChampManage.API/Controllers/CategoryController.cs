using ChampManage.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChampManage.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository; 

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult GetPredefinedCategories()
        {
            var categories = _categoryRepository.GetPredefinedCategories(); 

            return Ok(categories);
        }
    }

}
