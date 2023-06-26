using MediatR;
using Session3.Data.Query;
using Session3.Model;
using Session3.Repository;

namespace Session3.Data.Handler
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        readonly IProductRepository _productRepository;

        public GetProductByIdHandler(IProductRepository productRepository)
        {
                _productRepository = productRepository;
        }
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductByID(request.Id);
        }
    }
}
