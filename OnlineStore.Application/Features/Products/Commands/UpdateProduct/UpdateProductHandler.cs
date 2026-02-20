using AutoMapper;
using MediatR;
using OnlineStore.Application.Common.DTOs.Products;
using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public UpdateProductHandler(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindByIdAsync(request.Id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.Id} not found.");
            }
            else
            {
                product.Update(request.Name, request.Description,
                    request.Price, request.Stock, request.Slug,
                    request.Picture, request.PictureAlt, request.PictureTitle, request.CategoryId);
                await _productRepository.UpdateAsync(product);
                return _mapper.Map<ProductDto>(product);
            }
        }
    }
}
