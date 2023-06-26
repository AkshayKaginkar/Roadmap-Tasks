using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Session2.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Description", "Name", "Price", "Size" },
                values: new object[,]
                {
                    { 1, "A traditional deep-dish pizza with sausage, cheese, and tomato sauce.", "Classic Chicago", 100.0, 0 },
                    { 2, "A deep-dish pizza loaded with assorted vegetables and cheese", "Chicago Veggie", 200.0, 1 },
                    { 3, "A deep-dish pizza packed with spicy meats, cheese, and tomato sauce", "Spicy Meat Lover's", 300.0, 2 },
                    { 4, "A classic brick oven pizza with fresh mozzarella, basil, and tomatoes", "Margherita", 200.0, 1 },
                    { 5, "A flavorful brick oven pizza topped with olives, feta cheese, and vegetables", "Mediterranean Delight", 300.0, 2 },
                    { 6, " An authentic Italian pizza with fresh mozzarella, basil, and tomatoes.", "Margherita Classica", 300.0, 2 },
                    { 7, " A heavenly Italian pizza topped with a blend of four cheeses.", "Quattro Formaggi", 200.0, 1 },
                    { 8, " A scrumptious Neapolitan pizza topped with artichokes, ham, mushrooms, and olives", "Margherita Napoletana", 300.0, 2 },
                    { 9, " A delightful Neapolitan pizza featuring sausage and sautéed broccoli rabe.", "Salsiccia e Friarielli", 300.0, 2 },
                    { 10, " A vibrant California-style pizza loaded with fresh vegetables and goat cheese.", "California Veggie", 200.0, 1 },
                    { 11, " A unique California-style pizza with a peanut sauce base, chicken, and veggies.", "BBQ Chicken", 300.0, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizzas");
        }
    }
}
