using FluentValidation;

namespace OnlineStore.Application.Features.Carts.Commands.RemoveFromCart
{
    public class RemoveFromCartValidator:AbstractValidator<RemoveFromCartCommand>
    {
        public RemoveFromCartValidator()
        {
            RuleFor(x => x.CartItemId)
                .GreaterThan(0)
                .WithMessage("Cart Item Id is required.");
        }
    }
}
