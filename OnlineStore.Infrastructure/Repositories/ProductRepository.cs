using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Interfaces;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {


        public ProductRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(long categoryId)
        {
            return await _dbSet.AsNoTracking().Where(x => x.CategoryId == categoryId && !x.IsDeleted).ToListAsync();
        }
    }
}
