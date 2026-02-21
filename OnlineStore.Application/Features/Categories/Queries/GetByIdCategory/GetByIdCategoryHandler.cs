using AutoMapper;
using MediatR;
using OnlineStore.Application.Common.DTOs.Categories;
using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Application.Features.Categories.Queries.GetByIdCategory
{
    public class GetByIdCategoryHandler : IRequestHandler<GetByIdCategoryQuery, CategoryDto>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        public GetByIdCategoryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {request.Id} not found.");
            }
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
