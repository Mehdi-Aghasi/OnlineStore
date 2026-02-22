using OnlineStore.Domain.Common;

namespace OnlineStore.Domain.Entities
{
    public class Cart:BaseEntity
    {
        public string UserId { get;private set; }
        public ICollection<CartItem> CartItems { get;private set; }

        public Cart() { }
        public Cart(string userId)
        {
            if(string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("User ID cannot be null or empty.", nameof(userId));
            UserId = userId;
            CartItems = new List<CartItem>();
        }

        public void AddCartItem(CartItem cartItem)
        {
            if (cartItem == null)
                throw new ArgumentNullException(nameof(cartItem), "Cart item cannot be null.");
            CartItems.Add(cartItem);
        }
            public void RemoveCartItem(CartItem cartItem)
            {
                if (cartItem == null)
                    throw new ArgumentNullException(nameof(cartItem), "Cart item cannot be null.");
                CartItems.Remove(cartItem);
        }
    }
}
