namespace OnlineStore.Application.Common.DTOs.Orders
{
    public record CreateOrderItemDto(
        long ProductId,
        int Quantity,
        decimal Price
    );
}
