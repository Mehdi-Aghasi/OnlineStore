using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Entities;
using System.Net.Http.Headers;

namespace OnlineStore.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get;set; }
        public DbSet<Category> Categories { get;set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
        
    }
}
