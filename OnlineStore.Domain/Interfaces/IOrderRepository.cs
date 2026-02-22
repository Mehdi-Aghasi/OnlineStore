using OnlineStore.Domain.Entities;

namespace OnlineStore.Domain.Interfaces
{
    public interface IOrderRepository:IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
        Task<Order?> GetOrderWithItemsAsync(long orderId);

    }
}
