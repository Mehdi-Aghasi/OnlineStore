using MediatR;

namespace OnlineStore.Application.Features.Carts.Commands.AddToCart
{
    public record AddToCartCommand(
        string UserId,
        long ProductId,
        int Quantity,
        decimal Price
    ) : IRequest;
}
