using Session6.Models;
using Session6.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Session6Test
{
    public class ProductRepositoryTest :IClassFixture<ProductDbFixture>
    {
        readonly ProductRepository _productRepository;

        public ProductRepositoryTest(ProductDbFixture productDbFixture)
        {
            _productRepository = new ProductRepository(productDbFixture._applicationDbContext);
            
        }

        [Fact]
        public void GetAllProductTest()
        {
            //Assign
            List<Product> expectedProducts = new List<Product>()
            {
                new Product() { Id = 1, Name = "Product1", Price = 200 },
                new Product() { Id = 2, Name = "Product2", Price = 100 }
            };

            //Act
            List<Product> actualProducts = _productRepository.GetAllProducts();

            //Assert
            Assert.Equal(expectedProducts[1].Name, actualProducts[1].Name);
        }

    }
}
