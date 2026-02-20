using MediatR;
using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _repository;

        public DeleteProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
          var product= await _repository.FindByIdAsync(request.Id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.Id} not found.");
            }
            else
            {
                await _repository.DeleteAsync(product);
            }
        }
    }
}
