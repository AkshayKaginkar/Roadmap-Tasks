using Session4.Model;
using Session4.Repositories;

namespace Session4.Services
{
    public class ProductService : IProductService
    {
        readonly IProductRepository _productRepository;
        readonly ILogger _logger;

        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public bool AddProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }

        public bool EditProduct(Product product)
        {
            return _productRepository.EditProduct(product);
        }

        public List<Product> GetAllProducts()
        {
            _logger.LogInformation("Visited all products");
            return _productRepository.GetAllProducts();
            
        }

        public Product GetProductByID(int id)
        {
            return _productRepository.GetProductByID(id);
        }
    }
}
