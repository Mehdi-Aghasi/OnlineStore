using AutoMapper;
using MediatR;
using OnlineStore.Application.Common.DTOs.Carts;
using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Application.Features.Carts.Queries.GetCartByUserId
{
    public class GetCartByUserIdHandler : IRequestHandler<GetCartByUserIdQuery, CartDto>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        public GetCartByUserIdHandler(ICartRepository cartRepository,IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }
        public async Task<CartDto> Handle(GetCartByUserIdQuery request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(request.UserId);
            if (cart == null)
            {
                throw new KeyNotFoundException($"Cart for user {request.UserId} not found.");
            }
            return _mapper.Map<CartDto>(cart);
        }
    }
}
