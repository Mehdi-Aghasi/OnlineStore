using MediatR;
using OnlineStore.Application.Features.Pyments.Commands.RequestPayment;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Interfaces;

public class RequestPaymentHandler : IRequestHandler<RequestPaymentCommand, string>
{
    private readonly IPaymentRepository _paymentRepo;
    private readonly IOrderRepository _orderRepo;

    public RequestPaymentHandler(IPaymentRepository paymentRepo, IOrderRepository orderRepo)
    {
        _paymentRepo = paymentRepo;
        _orderRepo = orderRepo;
    }

    public async Task<string> Handle(RequestPaymentCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepo.GetByIdAsync(request.OrderId);
        if (order == null) throw new KeyNotFoundException("Order not found");

        var payment = new Payment(order.Id, order.TotalAmount, "ZarinPal");
        await _paymentRepo.AddAsync(payment);

        return ($"https://fake-payment.com/pay?paymentId={payment.Id}&amount={payment.Amount}");
    }
}