using MediatR;

namespace OnlineStore.Application.Features.Pyments.Commands.VerifyPayment
{
    public record VerifyPaymentCommand(string Authority, string Status) : IRequest<bool>;
}
