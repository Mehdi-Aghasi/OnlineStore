using OnlineStore.Domain.Common;

namespace OnlineStore.Domain.Entities
{
    public class Product:BaseEntity
    {
        public Guid UId { get; private set; }= Guid.NewGuid();
        public string Name { get;private set; }
        public string Description { get;private set; }
        public decimal Price { get;private set; }
        public int Stock { get;private set; }
        public string Slug { get;private set; }
        public string Picture { get;private set; }
        public string PictureAlt { get;private set; }
        public string PictureTitle { get;private set; }
        public long CategoryId { get;private set; }
        public Category Category { get;private set; }

        public Product(string name, string description, decimal price, string slug,int categoryid)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be null or empty.", nameof(name));
            if(price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");
            Name = name;
            Description = description;
            Price = price;
            Stock = 0;
            Slug = slug;
            CategoryId= categoryid;
        }


    }
}
