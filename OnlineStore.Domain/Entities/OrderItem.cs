using OnlineStore.Domain.Common;

namespace OnlineStore.Domain.Entities
{
    public class OrderItem: BaseEntity
    {
        public long OrderId { get; private set; }
        public long ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public Order Order { get; private set; }
        public Product Product { get; private set; }


        public OrderItem(long productId, long orderId, int quantity, decimal price)
        {
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");
            if (productId <= 0)
                throw new ArgumentOutOfRangeException(nameof(productId), "Product ID must be greater than zero.");
            ProductId = productId;
            OrderId = orderId;
            Quantity = quantity;
            Price = price;
        }

    }
}
