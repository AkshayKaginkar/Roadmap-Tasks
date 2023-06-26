using Microsoft.EntityFrameworkCore;
using Session3.Context;
using Session3.Model;

namespace Session3.Repository
{
    public class ProductRepository : IProductRepository
    {

        readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {

            _applicationDbContext = applicationDbContext;
        }


        public async Task<bool> AddProduct(Product product)
        {
            await _applicationDbContext.Products.AddAsync(product);
            _applicationDbContext.SaveChanges();
            return true;
        }

        public Task<int> DeleteProduct(int id)
        {
            Product product = _applicationDbContext.Products.FirstOrDefault(x => x.Id == id);
            _applicationDbContext.Products.Remove(product);
            return  _applicationDbContext.SaveChangesAsync();
        }

        public  Task<int> EditProduct(Product product)
        {

             _applicationDbContext.Products.Update(product);
            return _applicationDbContext.SaveChangesAsync();
            
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _applicationDbContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductByID(int id)
        {
            return await _applicationDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}