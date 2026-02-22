using MediatR;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Application.Features.Carts.Commands.AddToCart
{
    public class AddToCartHandler : IRequestHandler<AddToCartCommand>
    {
        private readonly ICartRepository _cartRepository;
        public AddToCartHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
          var cart= await _cartRepository.GetCartByUserIdAsync(request.UserId);
            if(cart== null)
            {
                cart=new Cart(request.UserId);
                await _cartRepository.AddAsync(cart);
            }
            var cartItem = new CartItem(
                cart.Id,
                request.ProductId,
                request.Quantity,
                request.Price
                );

            cart.AddCartItem(cartItem);
            await _cartRepository.UpdateAsync(cart);
        }
    }
}
