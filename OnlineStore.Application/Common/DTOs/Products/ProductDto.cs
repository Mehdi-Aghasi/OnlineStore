using MediatR;

namespace OnlineStore.Application.Common.DTOs.Products
{
    public record ProductDto(
        Guid uid,
        string Name,
        string Description,
        decimal Price,
        int Stock,
        string Slug,
        string Picture,
        string PictureAlt,
        string PictureTitle,
        string CategoryName
        );
    
}
