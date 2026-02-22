using MediatR;
using OnlineStore.Application.Common.DTOs.Orders;

namespace OnlineStore.Application.Features.Orders.Queries.GetOrderById
{
    public record GetOrderByIdQuery(long Id) : IRequest<OrderDto>;
}
