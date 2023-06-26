using Session4.Model;

namespace Session4.Repositories
{
    public interface IProductRepository
    {
        bool AddProduct(Product product);
        void DeleteProduct(int id);
        bool EditProduct(Product product);
        List<Product> GetAllProducts();
        Product GetProductByID(int id);
    }
}
