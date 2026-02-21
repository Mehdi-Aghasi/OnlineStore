using MediatR;

namespace OnlineStore.Application.Features.Categories.Commands.CreateCategory
{
    public record CreateCategoryCommand(
        string Name,
        string Description,
        string Slug
    ) : IRequest<long>;
}
