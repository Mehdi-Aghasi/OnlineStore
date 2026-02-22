namespace OnlineStore.Application.Common.DTOs.Orders
{
    public record OrderDto(
        long Id,
        string CustomerName,
        decimal TotalAmount,
        string ShippingAddress,
        string OrderStatus,
        DateTime CreatedAt,
        List<OrderItemDto> OrderItems
    );
}
