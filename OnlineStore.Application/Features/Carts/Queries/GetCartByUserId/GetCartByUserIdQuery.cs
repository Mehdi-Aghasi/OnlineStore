using MediatR;
using OnlineStore.Application.Common.DTOs.Carts;

namespace OnlineStore.Application.Features.Carts.Queries.GetCartByUserId
{
    public record GetCartByUserIdQuery(
        string UserId
        ) : IRequest<CartDto>;
}
