using MediatR;
using OnlineStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Application.Features.Orders.Commands.UpdateOrderStatus
{
    public class UpdateOrderStatusHandler : IRequestHandler<UpdateOrderStatusCommand>
    {
        private readonly IOrderRepository _repository;

        public UpdateOrderStatusHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.FindByIdAsync(request.OrderId);
            if (order == null)
                throw new KeyNotFoundException($"Order with ID {request.OrderId} not found.");

            order.UpdateStatus(request.NewStatus);
            await _repository.UpdateAsync(order);
        }
    }
}
