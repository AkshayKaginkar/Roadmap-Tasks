using Session6.Models;
using Session6.Repositories;

namespace Session6.Services
{
    public class ProductService : IProductService
    {
        readonly IProductRepository _productRepository;


        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
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
            return _productRepository.GetAllProducts();
        }

        public Product GetProductByID(int id)
        {
            return _productRepository.GetProductByID(id);
        }
    }
}