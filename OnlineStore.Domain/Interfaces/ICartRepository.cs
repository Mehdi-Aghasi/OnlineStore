using OnlineStore.Domain.Entities;

namespace OnlineStore.Domain.Interfaces
{
    public interface ICartRepository:IGenericRepository<Cart>
    {
        Task<Cart?> GetCartByUserIdAsync(string userId);
    }
}
