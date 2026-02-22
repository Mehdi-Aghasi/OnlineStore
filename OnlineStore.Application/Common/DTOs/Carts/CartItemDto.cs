namespace OnlineStore.Application.Common.DTOs.Carts
{
    public record CartItemDto(
        long Id,
        long ProductId,
        string ProductName,
        int Quantity,
        decimal Price
        );
}
