using Session6.Context;
using Session6.Models;

namespace Session6.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly ApplicationDbContext _applicationDbContext;
        public ProductRepository(ApplicationDbContext applicationDbContext)
        {

            _applicationDbContext = applicationDbContext;
        }

        public bool AddProduct(Product product)
        {
            _applicationDbContext.Products.Add(product);
            _applicationDbContext.SaveChanges();
            return true;
        }

        public void DeleteProduct(int id)
        {
            Product product = _applicationDbContext.Products.FirstOrDefault(x => x.Id == id);
            _applicationDbContext.Products.Remove(product);
            _applicationDbContext.SaveChanges();
        }

        public bool EditProduct(Product product)
        {
            _applicationDbContext.Products.Update(product);
            _applicationDbContext.SaveChanges();
            return true;
        }
        public List<Product> GetAllProducts()
        {
            return _applicationDbContext.Products.ToList();
        }

        public Product GetProductByID(int id)
        {
            return _applicationDbContext.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}