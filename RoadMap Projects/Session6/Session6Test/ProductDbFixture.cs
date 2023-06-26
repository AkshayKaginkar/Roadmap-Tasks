using Microsoft.EntityFrameworkCore;
using Session6.Context;
using Session6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session6Test
{
    public class ProductDbFixture
    {

        internal ApplicationDbContext _applicationDbContext;

        public ProductDbFixture()
        {
            var applicationDbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("ProductInMemDB").Options;
            _applicationDbContext = new ApplicationDbContext(applicationDbContextOptions );
            _applicationDbContext.Add(new Product() { Id = 1, Name = "Product1", Price = 200 });
            _applicationDbContext.Add(new Product() { Id = 2, Name = "Product2", Price = 100 });
            _applicationDbContext.SaveChanges();
        }


    }
}
