using AutoMapper;
using MediatR;
using OnlineStore.Application.Common.DTOs.Products;
using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Application.Features.Products.Queries.GetByIdProduct
{
    public class GetByIdProductHandler : IRequestHandler<GetByIdProductQuery, ProductDto>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdProductHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.Id} not found.");
            }
            return _mapper.Map<ProductDto>(product);
        }
    }
}
