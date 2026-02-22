using OnlineStore.Domain.Common;

namespace OnlineStore.Domain.Entities
{
    public class CartItem:BaseEntity
    {
        public long CartId { get;private set; }
        public long ProductId { get;private set; }
        public int Quantity { get;private set; }
        public decimal Price { get;private set; }
        public Cart Cart { get;private set; }
        public Product Product { get;private set; }

        public CartItem(long id,long productId,int quantity,decimal price)
        {
            if(id <= 0)
                throw new ArgumentException("Cart ID must be greater than zero.", nameof(id));
            if(productId <= 0)
                throw new ArgumentException("Product ID must be greater than zero.", nameof(productId));
            if(quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
            CartId = id;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }
    }
}
