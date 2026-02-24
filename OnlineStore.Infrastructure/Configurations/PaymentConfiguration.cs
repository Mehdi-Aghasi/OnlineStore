using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.Entities;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Amount).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(p => p.TransactionId).HasMaxLength(100);
        builder.HasOne(p => p.Order).WithOne().HasForeignKey<Payment>(p => p.OrderId);
        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}