using OnlineStore.Domain.Entities;

namespace OnlineStore.Domain.Interfaces
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(long categoryId);
    }
}
