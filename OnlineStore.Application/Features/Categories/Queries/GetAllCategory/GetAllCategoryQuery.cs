using MediatR;
using OnlineStore.Application.Common.DTOs.Categories;

namespace OnlineStore.Application.Features.Categories.Queries.GetAllCategory
{
    public record GetAllCategoryQuery(
    ) : IRequest<IEnumerable<CategoryDto>>;
}
