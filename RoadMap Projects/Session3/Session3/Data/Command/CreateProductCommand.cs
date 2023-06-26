using MediatR;
using Session3.Model;

namespace Session3.Data.Command
{
    public class CreateProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public CreateProductCommand(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

    }
}
