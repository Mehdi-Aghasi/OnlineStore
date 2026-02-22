using AutoMapper;
using MediatR;
using OnlineStore.Application.Common.DTOs.Orders;
using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Application.Features.Orders.Queries.GetOrderByUserId
{
    public class GetOrdersByUserIdHandler : IRequestHandler<GetOrdersByUserIdQuery, IEnumerable<OrderDto>>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public GetOrdersByUserIdHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _repository.GetOrdersByUserIdAsync(request.UserId);
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }
    }
}
