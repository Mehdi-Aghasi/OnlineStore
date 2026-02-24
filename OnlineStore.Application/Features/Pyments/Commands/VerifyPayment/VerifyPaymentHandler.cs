using MediatR;
using OnlineStore.Application.Features.Pyments.Commands.VerifyPayment;
using OnlineStore.Domain.Common.Enums;
using OnlineStore.Domain.Interfaces;

public class VerifyPaymentHandler : IRequestHandler<VerifyPaymentCommand, bool>
{
    private readonly IPaymentRepository _paymentRepo;
    private readonly IOrderRepository _orderRepo;

    public VerifyPaymentHandler(IPaymentRepository paymentRepo, IOrderRepository orderRepo)
    {
        _paymentRepo = paymentRepo;
        _orderRepo = orderRepo;
    }

    public async Task<bool> Handle(VerifyPaymentCommand request, CancellationToken cancellationToken)
    {
        if (!long.TryParse(request.Authority, out long paymentId)) return false;

        var payment = await _paymentRepo.GetByIdAsync(paymentId);
        if (payment == null) return false;

        if (request.Status == "OK")
        {
            payment.Success(Guid.NewGuid().ToString()); 
            await _paymentRepo.UpdateAsync(payment);

            var order = await _orderRepo.GetByIdAsync(payment.OrderId);
            if (order != null)
            {
                order.UpdateStatus(OrderStatus.Paid);
                await _orderRepo.UpdateAsync(order);
            }
            return true;
        }
        else
        {
            payment.Fail();
            await _paymentRepo.UpdateAsync(payment);
            return false;
        }
    }
}