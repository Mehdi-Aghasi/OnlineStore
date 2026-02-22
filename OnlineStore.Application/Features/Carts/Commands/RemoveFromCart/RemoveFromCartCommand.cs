using MediatR;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.Carts.Commands.RemoveFromCart
{
    public record RemoveFromCartCommand(
        long CartItemId
        ):IRequest;
}
