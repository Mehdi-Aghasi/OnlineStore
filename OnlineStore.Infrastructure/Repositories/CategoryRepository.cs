using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Interfaces;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repositories
{
    public class CategoryRepository:GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }
    }
}
