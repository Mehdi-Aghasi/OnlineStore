using AutoMapper;
using MediatR;
using OnlineStore.Application.Common.DTOs.Products;
using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Application.Features.Products.Queries.GetProductByCategoryId
{
    public class GetProductByCategoryIdHandler : IRequestHandler<GetProductByCategoryIdQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByCategoryIdHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> Handle(GetProductByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var product=await _productRepository.GetProductsByCategoryIdAsync(request.CategoryId);
                return _mapper.Map<IEnumerable<ProductDto>>(product);
        }
    }
}
