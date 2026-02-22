using OnlineStore.Domain.Common;
using OnlineStore.Domain.Common.Enums;

namespace OnlineStore.Domain.Entities
{
    public class Order: BaseEntity
    {
        public string UserId { get; private set; }
        public string CustomerName { get; private set; }
        public decimal TotalAmount { get; private set; }
        public DateTime OrderDate { get; private set; }
        public string ShippingAddress { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public ICollection<OrderItem> OrderItems { get; private set; }

        public Order(string userId, string customerName)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("User ID cannot be null or empty.", nameof(userId));
            if (string.IsNullOrWhiteSpace(customerName))
                throw new ArgumentException("Customer name cannot be null or empty.", nameof(customerName));
            UserId = userId;
            CustomerName = customerName;
            OrderDate = DateTime.UtcNow;
            OrderStatus = OrderStatus.Pending;
            OrderItems = new List<OrderItem>();
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            OrderStatus = newStatus;
            UpdatedAt = DateTime.UtcNow;
        }

    }
}
