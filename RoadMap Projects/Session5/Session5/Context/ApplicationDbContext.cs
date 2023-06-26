using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Session5.Configurations;
using Session5.Models;

namespace Session5.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "Product1", Price = 100 },
                new Product() { Id = 2, Name = "Product2", Price = 200 },
                new Product() { Id = 3, Name = "Product3", Price = 300 }
            );

            modelBuilder.ApplyConfiguration(new RoleSeedConfiguration());
        }

        public DbSet<Product> Products { get; set; }
    }
}
