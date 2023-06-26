using Session3.Model;

namespace Session3.Services
{
    public interface IProductService
    {
        Task<bool> AddProduct(Product product);
        Task<bool> DeleteProduct(int id);
        Task<bool> EditProduct(Product product);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductByID(int id);
    }
}
