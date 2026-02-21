using MediatR;
using OnlineStore.Application.Common.DTOs.Categories;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.Categories.Commands.UpdateCategory
{
    public record UpdateCategoryCommand(
        long Id,
        string Name,
        string Description,
        string Slug
    ) : IRequest<CategoryDto>;
}
