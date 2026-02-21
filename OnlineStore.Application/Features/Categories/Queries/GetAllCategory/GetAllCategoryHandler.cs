using AutoMapper;
using MediatR;
using OnlineStore.Application.Common.DTOs.Categories;
using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Application.Features.Categories.Queries.GetAllCategory
{
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuery, IEnumerable<CategoryDto>>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        public GetAllCategoryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }
    }
}
