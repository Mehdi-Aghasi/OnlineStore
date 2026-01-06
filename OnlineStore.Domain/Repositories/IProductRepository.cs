using OnlineStore.Domain.Entities;

namespace OnlineStore.Domain.Repositories
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(long categoryId);
    }
}
