using MediatR;
using OnlineStore.Application.Common.DTOs.Products;

namespace OnlineStore.Application.Features.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand(
        long Id,
        string Name,
        string Description,
        int Stock,
        decimal Price,
        string Slug,
        string Picture,
        string PictureAlt,
        string PictureTitle,
        long CategoryId
        ) :IRequest<ProductDto>;

}
