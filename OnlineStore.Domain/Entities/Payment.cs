using OnlineStore.Domain.Common;

namespace OnlineStore.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public decimal Amount { get; private set; }
        public string TransactionId { get; private set; }
        public bool IsSuccessful { get; private set; }
        public string Gateway { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public long OrderId { get; private set; }
        public Order Order { get; private set; }
        public Payment(long orderId, decimal amount, string gateway)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
            OrderId = orderId;
            Amount = amount;
            Gateway = gateway;
            IsSuccessful = false;
            PaymentDate = DateTime.UtcNow;
        }

        public void Success(string transactionId)
        {
            TransactionId = transactionId;
            IsSuccessful = true;
            PaymentDate = DateTime.UtcNow;
        }

        public void Fail()
        {
            IsSuccessful = false;
        }
    }
}