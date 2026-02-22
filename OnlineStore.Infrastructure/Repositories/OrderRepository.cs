using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Interfaces;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repositories
{
    public class OrderRepository:GenericRepository<Order>,IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
        {
            return await _dbSet
                .Where(o => o.UserId == userId && !o.IsDeleted)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderWithItemsAsync(long orderId)
        {
            return await _dbSet
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId && !o.IsDeleted);
        }
    }
}
