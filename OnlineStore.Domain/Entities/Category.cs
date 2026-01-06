using OnlineStore.Domain.Common;

namespace OnlineStore.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get;private set; }
        public string Description { get;private set; }
        public string Slug { get;private set; }
        public ICollection<Product> Products { get; set; }
        public Category(string name, string description, string slug)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Category name cannot be null or empty.", nameof(name));
            Name = name;
            Description = description;
            Slug = slug;
        }
    }
}
