using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Interfaces;

public interface IPaymentRepository : IGenericRepository<Payment>
{
    Task<Payment?> GetByOrderIdAsync(long orderId);
    Task<Payment?> GetByTransactionIdAsync(string transactionId);
}