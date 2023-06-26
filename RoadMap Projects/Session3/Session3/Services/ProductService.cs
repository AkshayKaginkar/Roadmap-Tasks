using MediatR;
using Session3.Data.Command;
using Session3.Data.Query;
using Session3.Model;
using Session3.Repository;

namespace Session3.Services
{
    public class ProductService : IProductService
    {
        readonly IMediator _mediator;
        

        public ProductService(IMediator mediator)
        {
            _mediator = mediator;
            
        }

        public async Task<bool> AddProduct(Product product)
        {
            return await _mediator.Send(new CreateProductCommand(product.Id, product.Name, product.Price));
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));

            if (result != 0)
                return true;
            return false;
        }

        public async Task<bool> EditProduct(Product product)
        {
            var result =  await _mediator.Send(new UpdateProductCommand(product.Id,product.Name,product.Price));

            if (result != 0)
                return true;
            return false;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _mediator.Send(new GetAllProductsQuery());

        }

        public async Task<Product> GetProductByID(int id)
        {
            return await _mediator.Send(new GetProductByIdQuery(id));
        }
    }
}