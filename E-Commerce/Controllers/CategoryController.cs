using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Category;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService categoryService;
        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = categoryService.GetAll();
            return Ok(categories); 
        }
    }
}
