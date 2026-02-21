using MediatR;
using OnlineStore.Application.Common.DTOs.Categories;

namespace OnlineStore.Application.Features.Categories.Queries.GetByIdCategory
{
    public record GetByIdCategoryQuery(
        long Id
    ) : IRequest<CategoryDto>;
}
