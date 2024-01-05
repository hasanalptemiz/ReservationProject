using Microsoft.AspNetCore.Mvc;
using CoreDominationBootCamp.Models;
using CoreDominationBootCamp.Services;

namespace CoreDominationBootCamp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;

         public ProductController(ProductService productService, CategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("getById/{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Product newProduct)
        {
            _productService.AddProduct(newProduct);
            return Ok(newProduct);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return Ok($"The product with id {id} has been deleted");
        }
}


}

