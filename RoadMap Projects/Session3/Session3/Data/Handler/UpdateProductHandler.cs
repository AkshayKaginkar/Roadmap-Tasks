using MediatR;
using Session3.Data.Command;
using Session3.Model;
using Session3.Repository;

namespace Session3.Data.Handler
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, int>
    {
        readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new Product()
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price,
            };
            return await _productRepository.EditProduct(product);
        }
    }
}
