using Session6.Models;

namespace Session6.Repositories
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
