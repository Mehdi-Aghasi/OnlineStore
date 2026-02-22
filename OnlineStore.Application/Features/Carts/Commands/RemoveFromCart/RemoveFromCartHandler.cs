using MediatR;
using OnlineStore.Application.Features.Carts.Commands.RemoveFromCart;
using OnlineStore.Domain.Interfaces;

public class RemoveFromCartHandler : IRequestHandler<RemoveFromCartCommand>
{
    private readonly ICartItemRepository _repository;

    public RemoveFromCartHandler(ICartItemRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveFromCartCommand request, CancellationToken cancellationToken)
    {
        var cartItem = await _repository.FindByIdAsync(request.CartItemId);
        if (cartItem == null)
        {
            throw new KeyNotFoundException($"CartItem with ID {request.CartItemId} not found.");
        }
        await _repository.DeleteAsync(cartItem);
    }
}