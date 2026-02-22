namespace OnlineStore.Application.Common.DTOs.Carts
{
    public record CartDto(
        long Id,
        string UserId,
        List<CartItemDto> Items
        );
}
