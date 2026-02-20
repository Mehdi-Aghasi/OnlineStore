using MediatR;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, long>
    {
        private readonly IProductRepository _repository;
        public CreateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(
                request.Name,
                request.Description,
                request.Price,
                request.Slug,
                request.CategoryId
             );
            await _repository.AddAsync(product);
            return product.Id;
        }
    }
}
