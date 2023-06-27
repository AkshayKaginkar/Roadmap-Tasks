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
            _logger.LogInformation($"New Product Added");
            return _productRepository.AddProduct(product);
        }

        public void DeleteProduct(int id)
        {
            _logger.LogInformation($"Product Deleted with id {id}");
            _productRepository.DeleteProduct(id);
        }

        public bool EditProduct(Product product)
        {
            _logger.LogInformation($"Product Updated with id {product.Id}");
            return _productRepository.EditProduct(product);
        }

        public List<Product> GetAllProducts()
        {
            _logger.LogInformation("Visited all products");
            return _productRepository.GetAllProducts();
            
        }

        public Product GetProductByID(int id)
        {
            _logger.LogInformation($"Get product hit with id {id}");
            return _productRepository.GetProductByID(id);
        }
    }
}
