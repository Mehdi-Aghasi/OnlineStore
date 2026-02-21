using MediatR;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, long>
    {
        private readonly ICategoryRepository _repository;
        public CreateCategoryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<long> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(
                request.Name,
                request.Description,
                request.Slug
             );
            await _repository.AddAsync(category);
            return category.Id;

        }
    }
}
