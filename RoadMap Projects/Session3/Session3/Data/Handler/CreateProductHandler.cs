using MediatR;
using Session3.Data.Command;
using Session3.Model;
using Session3.Repository;

namespace Session3.Data.Handler
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, bool>
    {
        readonly IProductRepository _repository;

        public CreateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new Product()
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price,
            };

            return await _repository.AddProduct(product);
        }
    }
}
