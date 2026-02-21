using MediatR;
using OnlineStore.Application.Common.DTOs.Products;

namespace OnlineStore.Application.Features.Products.Queries.GetProductByCategoryId
{
    public record GetProductByCategoryIdQuery(long CategoryId) : IRequest<IEnumerable<ProductDto>>;
}
