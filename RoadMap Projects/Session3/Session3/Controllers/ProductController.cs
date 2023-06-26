using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session3.Model;
using Session3.Services;

namespace Session3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
       
        public async Task<ActionResult> Products()
        {
            List<Product> allproducts = await _productService.GetAllProducts();
            return Ok(allproducts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductByID(int id)
        {
            Product product = await _productService.GetProductByID(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> AddProductAsync(Product product)
        {
            bool status = await _productService.AddProduct(product);
            if (status)
            return Created("api/Created", status);
            return BadRequest();

        }

        [HttpPut]
        public async Task<ActionResult> EditProduct(Product product)
        {
            bool status = await _productService.EditProduct(product);
            if (status == true)
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            bool status = await _productService.DeleteProduct(id);
            if (status == true)
                return Ok();
            else
                return NotFound();
        }



    }
}

