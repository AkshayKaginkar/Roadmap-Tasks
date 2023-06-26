using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session4.Model;
using Session4.Services;

namespace Session4.Controllers
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
        [Route("/products")]
        public ActionResult Products()
        {
            List<Product> allproducts = _productService.GetAllProducts();
            return Ok(allproducts);
        }

        [HttpGet]
        public ActionResult GetProductByID(int id)
        {
            Product product = _productService.GetProductByID(id);
            return Ok(product);
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            bool status = _productService.AddProduct(product);
            return Created("api/Created", status);

        }

        [HttpPut]
        public ActionResult EditProduct(Product product)
        {
            bool status = _productService.EditProduct(product);
            if (status == true)
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }



    }
}
