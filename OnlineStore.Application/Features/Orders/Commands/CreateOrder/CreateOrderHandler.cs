using MediatR;
using OnlineStore.Application.Features.Orders.Commands.CreateOrder;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Interfaces;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, long>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<long> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order(
            request.UserId,
            request.CustomerName
        );

        foreach (var item in request.Items)
        {
            var orderItem = new OrderItem(
                item.ProductId,
                order.Id,
                item.Quantity,
                item.Price
            );
            order.OrderItems.Add(orderItem);
        }

        await _orderRepository.AddAsync(order);
        return order.Id;
    }
}