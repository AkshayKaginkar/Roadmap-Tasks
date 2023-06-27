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

        //[Fact]
        public void DeleteProductTest()
        {
            //assign
            Product product = null;

            //act
            _productRepository.DeleteProduct(2);
            product = _productRepository.GetProductByID(2);

            //assert
            Assert.Null(product);
            _productRepository.AddProduct(new Product() { Id = 2, Name = "Product2", Price = 100 });


        }

        [Fact]
        public void GetProductByIdTest()
        {
            //assign
            Product Expectedproduct = new Product() { Id = 1, Name = "Product1", Price = 200 };

            //act
            Product ActualProduct = _productRepository.GetProductByID(1);

            //Assert
            Assert.Equal(Expectedproduct.Name, ActualProduct.Name);
            
        }

        [Fact]
        public void AddProductTest()
        {
            //assign
            int count = 3;

            //act
            _productRepository.AddProduct(new Product { Id = 3, Name = "product3", Price = 100 });

            //Assert
            Assert.Equal(count, _productRepository.GetAllProducts().Count);

            
        }

    }
}
