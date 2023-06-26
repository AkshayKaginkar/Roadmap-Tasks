using Session1.Models;

namespace Session1.Services
{
    public class ProductService : IProductService
    {
        List<Product> products;

        public ProductService()
        {
            products = new List<Product>()
            {
                new Product() {Id=1, Name="Product1",Price= 100},
                new Product() {Id=2,Name="Product2",Price= 200},
                new Product() {Id=3,Name="Product3",Price= 300}
            };

        }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            products.Remove(product);
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProductByID(int id)
        {
            Product product= products.Find(p => p.Id == id);
            if (product != null)
                return product;
            else
                throw new NullReferenceException();
        }

        public void UpdateProduct(Product product)
        {
            Product existing = GetProductByID(product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
            }
        }
    }
}
