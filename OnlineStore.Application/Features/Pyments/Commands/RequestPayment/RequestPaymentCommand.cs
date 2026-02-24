using MediatR;

namespace OnlineStore.Application.Features.Pyments.Commands.RequestPayment
{
    public record RequestPaymentCommand(long OrderId) : IRequest<string>; 
}
