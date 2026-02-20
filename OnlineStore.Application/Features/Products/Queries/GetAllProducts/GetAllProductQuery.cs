using MediatR;
using OnlineStore.Application.Common.DTOs.Products;

namespace OnlineStore.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductQuery : IRequest<IEnumerable<ProductDto>> { }

}
