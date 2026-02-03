using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Infrastructure.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                 .IsRequired()
                 .HasMaxLength(100);
            builder.Property(p => p.Description)
                  .HasMaxLength(1000);
            builder.Property(p => p.Price)
                  .IsRequired()
                  .HasColumnType("decimal(18,2)");
            builder.Property(p => p.Stock)
                  .IsRequired();
            builder.Property(p => p.Slug)
                    .IsRequired()
                    .HasMaxLength(150);
            builder.HasOne(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId);

            builder.HasQueryFilter(p=>!p.IsDeleted);
        }
    }
}
