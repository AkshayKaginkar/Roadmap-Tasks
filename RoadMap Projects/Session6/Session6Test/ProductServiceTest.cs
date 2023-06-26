using Moq;
using Session6.Models;
using Session6.Repositories;
using Session6.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Session6Test
{
    public class ProductServiceTest
    {
        [Fact]
        public void GetAllProductsServiceTest()
        {
                // Arrange
                var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1" },
                new Product { Id = 2, Name = "Product 2" },
                new Product { Id = 3, Name = "Product 3" }
            };
            var mockRepository = new Mock<IProductRepository>();
            mockRepository.Setup(repo => repo.GetAllProducts()).Returns(products);

            var productService = new ProductService(mockRepository.Object);

            // Act
            var result = productService.GetAllProducts();

            // Assert
            Assert.Equal(products, result);
        }
        }
    }
