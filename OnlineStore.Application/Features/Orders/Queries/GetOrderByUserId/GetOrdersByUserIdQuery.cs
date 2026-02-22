using MediatR;
using OnlineStore.Application.Common.DTOs.Orders;

namespace OnlineStore.Application.Features.Orders.Queries.GetOrderByUserId
{
    public record GetOrdersByUserIdQuery(string UserId) : IRequest<IEnumerable<OrderDto>>;
}
