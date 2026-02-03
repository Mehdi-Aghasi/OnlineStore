using OnlineStore.Domain.Common;

namespace OnlineStore.Domain.Entities
{
    public class Category:BaseEntity
    {
        public  Guid UId { get;private set; }= Guid.NewGuid();
        public string Name { get;private set; }
        public string Description { get;private set; }
        public string Slug { get;private set; }
        public ICollection<Product> Products { get; private set; }
        public Category(string name, string description, string slug)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Category name cannot be null or empty.", nameof(name));
            Name = name;
            Description = description;
            Slug = slug;
            Products = new List<Product>();
        }
    }
}
