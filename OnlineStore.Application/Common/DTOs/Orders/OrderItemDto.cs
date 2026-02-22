namespace OnlineStore.Application.Common.DTOs.Orders
{
    public record OrderItemDto(
        long ProductId,
        string ProductName,
        decimal UnitPrice,
        int Quantity
    );
}
