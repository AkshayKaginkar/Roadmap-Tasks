using MediatR;
using Session3.Model;

namespace Session3.Data.Query
{
    public class GetAllProductsQuery : IRequest<List<Product>>
    {
        public GetAllProductsQuery()
        {
            
        }
    }
}
