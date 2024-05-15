using DTOs.Create;
using DTOs.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using Services.Order;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;

        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult GetAll()
        {
            var Products = productService.GetAll();
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var product = productService.GetOne(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create([FromBody] CreateProductDTO product)
        {
            var productS = productService.Create(product);
            return Ok(productS);

        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(UpdateProduct product , int id)
        {
            var pro = productService.GetOne(id);
            if (pro == null)
            {
                return NotFound();
            }
            var products = productService.Update(product , id);
            return Ok(products);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var deletedProduct = productService.Delete(id);
            if (deletedProduct == null)
            {
                return NotFound();
            }
            return Ok(deletedProduct);
        }

    }
}
