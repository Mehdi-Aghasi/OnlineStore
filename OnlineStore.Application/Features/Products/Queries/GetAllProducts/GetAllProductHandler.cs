using AutoMapper;
using MediatR;
using OnlineStore.Application.Common.DTOs.Products;
using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public GetAllProductHandler(IProductRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

      
        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}
