using OnlineStore.Domain.Common;

namespace OnlineStore.Domain.Entities
{
    public class Product:BaseEntity
    {
        public Guid ProductId { get;private set; }
        public string Name { get;private set; }
        public string Description { get;private set; }
        public decimal Price { get;private set; }
        public int Stock { get;private set; }
        public string Slug { get;private set; }
        public string Picture { get;private set; }
        public string PictureAlt { get;private set; }
        public string PictureTitle { get;private set; }
        //public int CategoryId { get; set; }
        //public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string slug, string picture, string pictureAlt, string pictureTitle)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be null or empty.", nameof(name));
            if(price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");

            ProductId = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Slug = slug;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
        }
    }
}
