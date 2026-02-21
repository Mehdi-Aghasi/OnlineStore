using MediatR;
using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        public DeleteCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category=await _categoryRepository.FindByIdAsync(request.Id);
            if(category == null)
            {
                throw new KeyNotFoundException($"Category with id {request.Id} not found.");
            }
            await _categoryRepository.DeleteAsync(category);
        }
    }
}
