using MediatR;

namespace OnlineStore.Application.Features.Products.Commands.CreateProduct
{
    public record CreateProductCommand(
        string Name,
        string Description,
        decimal Price,
        int StockQuantity,
        string Slug,
        long CategoryId
    ):IRequest<long>;
}
