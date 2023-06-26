using MediatR;
using Session3.Model;

namespace Session3.Data.Command
{
    public class DeleteProductCommand : IRequest<int>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
