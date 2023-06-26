using Microsoft.AspNetCore.Mvc;
using Session1.Models;
using Session1.Services;

namespace Session1.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [Route("product/getallproducts")]
        public ActionResult GetAllProducts()
        {
            List<Product> allproducts = _productService.GetAllProducts();
            return View(allproducts);
        }
        [Route("product/details/{id}")]
        public ActionResult Details(int id)
        {
            Product product = _productService.GetProductByID(id);
            return View(product);
        }

        [Route("product/create")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("product/create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            _productService.AddProduct(product);
            return RedirectToAction("GetAllProducts");
        }

        [Route("product/edit/{id}")]
        public ActionResult Edit(int id)
        {
            Product product = _productService.GetProductByID(id);
            return View(product);
        }

        [Route("product/edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            _productService.UpdateProduct(product);
            return RedirectToAction("GetAllProducts");
        }

        [Route("product/delete/{id}")]
        public ActionResult Delete(int id)
        {
            Product product = _productService.GetProductByID(id);
            return View(product);
        }


       // [Route("product/delete/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            Product product = _productService.GetProductByID(id);
            _productService.DeleteProduct(product);
            return RedirectToAction("GetAllProducts");

        }
    }
}
