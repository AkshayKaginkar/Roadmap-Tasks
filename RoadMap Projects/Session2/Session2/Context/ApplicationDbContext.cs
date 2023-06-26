using Microsoft.EntityFrameworkCore;
using Session2.Constants;
using Session2.Models;

namespace Session2.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza
                {
                    Id = 1,
                    Name = "Classic Chicago",
                    Description = "A traditional deep-dish pizza with sausage, cheese, and tomato sauce.",
                    Size = PizzaSize.Small,
                    Price = 100.0
                },
                new Pizza
                {
                    Id = 2,
                    Name = "Chicago Veggie",
                    Description = "A deep-dish pizza loaded with assorted vegetables and cheese",
                    Size = PizzaSize.Medium,
                    Price = 200.0
                },
                new Pizza
                {
                    Id = 3,
                    Name = "Spicy Meat Lover's",
                    Description = "A deep-dish pizza packed with spicy meats, cheese, and tomato sauce",
                    Size = PizzaSize.Large,
                    Price = 300.0
                },
                new Pizza
                {
                    Id = 4,
                    Name = "Margherita",
                    Description = "A classic brick oven pizza with fresh mozzarella, basil, and tomatoes",
                    Size = PizzaSize.Medium,
                    Price = 200.0
                },

                new Pizza
                {
                    Id = 5,
                    Name = "Mediterranean Delight",
                    Description = "A flavorful brick oven pizza topped with olives, feta cheese, and vegetables",
                    Size = PizzaSize.Large,
                    Price = 300.0
                },

                new Pizza
                {
                    Id = 6,
                    Name = "Margherita Classica",
                    Description = " An authentic Italian pizza with fresh mozzarella, basil, and tomatoes.",
                    Size = PizzaSize.Large,
                    Price = 300.0
                },

                new Pizza
                {
                    Id = 7,
                    Name = "Quattro Formaggi",
                    Description = " A heavenly Italian pizza topped with a blend of four cheeses.",
                    Size = PizzaSize.Medium,
                    Price = 200.0
                },

                new Pizza
                {
                    Id = 8,
                    Name = "Margherita Napoletana",
                    Description = " A scrumptious Neapolitan pizza topped with artichokes, ham, mushrooms, and olives",
                    Size = PizzaSize.Large,
                    Price = 300.0
                },

                new Pizza
                {
                    Id = 9,
                    Name = "Salsiccia e Friarielli",
                    Description = " A delightful Neapolitan pizza featuring sausage and sautéed broccoli rabe.",
                    Size = PizzaSize.Large,
                    Price = 300.0
                },

                 new Pizza
                 {
                     Id = 10,
                     Name = "California Veggie",
                     Description = " A vibrant California-style pizza loaded with fresh vegetables and goat cheese.",
                     Size = PizzaSize.Medium,
                     Price = 200.0
                 },
                 new Pizza
                 {
                     Id = 11,
                     Name = "BBQ Chicken",
                     Description = " A unique California-style pizza with a peanut sauce base, chicken, and veggies.",
                     Size = PizzaSize.Large,
                     Price = 300.0
                 }
            );
        }

        public DbSet<Pizza> Pizzas { get; set; }

    }
}
