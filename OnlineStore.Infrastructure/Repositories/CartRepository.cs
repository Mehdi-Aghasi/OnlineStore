using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Interfaces;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(ApplicationDbContext context) : base(context) { }
        public async Task<Cart?> GetCartByUserIdAsync(string userId)
        {
            return await _dbSet.
                  Include(c => c.CartItems)
                  .ThenInclude(p => p.Product)
                  .FirstOrDefaultAsync(c => c.UserId == userId && !c.IsDeleted);
        }
    }
}
