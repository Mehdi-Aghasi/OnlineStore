using MediatR;
using OnlineStore.Domain.Common.Enums;

namespace OnlineStore.Application.Features.Orders.Commands.UpdateOrderStatus
{
    public record UpdateOrderStatusCommand(
    long OrderId,
    OrderStatus NewStatus
) : IRequest;
}
