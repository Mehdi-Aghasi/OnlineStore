using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Infrastructure.Configurations
{
    public class OrderConfiguration:IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.UserId)
                .IsRequired()
                .HasMaxLength(450);
            builder.Property(o => o.CustomerName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(o => o.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.Property(o => o.ShippingAddress)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(o => o.OrderStatus)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);
            builder.HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasQueryFilter(o => !o.IsDeleted);
        }
    }
}
