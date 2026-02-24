using MediatR;
using OnlineStore.Application.Features.Carts.Commands.RemoveFromCart;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Interfaces;

public class RemoveFromCartHandler : IRequestHandler<RemoveFromCartCommand>
{
    private readonly IGenericRepository<CartItem> _repository;

    public RemoveFromCartHandler(IGenericRepository<CartItem> repository)
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