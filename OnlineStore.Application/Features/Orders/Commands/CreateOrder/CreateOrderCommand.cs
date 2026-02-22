using MediatR;
using OnlineStore.Application.Common.DTOs.Orders;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.Orders.Commands.CreateOrder
{
     public record CreateOrderCommand(
         string UserId,
         string CustomerName,
         string ShippingAddress,
         List<CreateOrderItemDto> Items
     ) : IRequest<long>;
}
