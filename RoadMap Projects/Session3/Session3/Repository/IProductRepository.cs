using Session3.Model;

namespace Session3.Repository
{
    public interface IProductRepository
    {
        Task<bool> AddProduct(Product product);
        Task<int> DeleteProduct(int id);
        Task<int> EditProduct(Product product);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductByID(int id);
    }
}
