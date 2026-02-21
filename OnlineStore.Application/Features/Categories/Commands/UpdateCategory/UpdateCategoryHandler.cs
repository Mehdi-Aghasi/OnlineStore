using AutoMapper;
using MediatR;
using OnlineStore.Application.Common.DTOs.Categories;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryHandler:IRequestHandler<UpdateCategoryCommand, CategoryDto>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        public UpdateCategoryHandler(ICategoryRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.FindByIdAsync(request.Id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {request.Id} not found.");
            }
            category.Update(request.Name, request.Description, request.Slug);
            await _repository.UpdateAsync(category);
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
