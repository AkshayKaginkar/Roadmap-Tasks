using Session1.Models;

namespace Session1.Services
{
    public interface IProductService
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        List<Product> GetAllProducts();
        Product GetProductByID(int id);
        void UpdateProduct(Product product);
    }
}
