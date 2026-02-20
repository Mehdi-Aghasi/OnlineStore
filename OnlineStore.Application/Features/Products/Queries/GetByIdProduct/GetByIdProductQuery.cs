using MediatR;
using OnlineStore.Application.Common.DTOs.Products;

namespace OnlineStore.Application.Features.Products.Queries.GetByIdProduct
{
    public record GetByIdProductQuery(long Id):IRequest<ProductDto>;


}
