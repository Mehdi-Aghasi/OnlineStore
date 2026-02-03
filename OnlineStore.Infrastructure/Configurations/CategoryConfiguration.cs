using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Infrastructure.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired();
            builder.Property(c => c.Description)
                .HasMaxLength(500);
            builder.Property(c => c.Slug)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasMany(c => c.Products)
                 .WithOne(p => p.Category)
                 .HasForeignKey(p => p.CategoryId);
        }
    }
}
