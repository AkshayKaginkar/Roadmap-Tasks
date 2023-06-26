using MediatR;
using Session3.Data.Command;
using Session3.Repository;

namespace Session3.Data.Handler
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, int>
    {
        readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _productRepository.DeleteProduct(request.Id);
        }
    }
}
