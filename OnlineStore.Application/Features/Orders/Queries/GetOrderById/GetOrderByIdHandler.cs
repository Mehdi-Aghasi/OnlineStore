using AutoMapper;
using OnlineStore.Application.Common.DTOs.Orders;
using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdHandler
    {

        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public GetOrderByIdHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetOrderWithItemsAsync(request.Id);
            if (order == null)
                throw new KeyNotFoundException($"Order with ID {request.Id} not found.");
            return _mapper.Map<OrderDto>(order);
        }
    }
}
