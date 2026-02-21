namespace OnlineStore.Application.Common.DTOs.Categories
{
    public record CategoryDto(
        long Id,
        string Name,
        string Description,
        string Slug
    );
}
