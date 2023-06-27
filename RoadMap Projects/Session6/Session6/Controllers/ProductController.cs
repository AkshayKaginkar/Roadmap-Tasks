using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session6.Extensions;
using Session6.Models;
using Session6.Services;
using System.Diagnostics;

namespace Session6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductService _productService;
        public static int getAllHits;
        public TimeSpan getAllResponseTime;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("/products")]
        public ActionResult Products()
        {
            //Stopwatch stopwatch = Stopwatch.StartNew();
            List<Product> allproducts = _productService.GetAllProducts();

            getAllHits++;
            //stopwatch.Stop();
          //  getAllResponseTime = stopwatch.Elapsed;
            //  throw new NullReferenceException("for check");
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
