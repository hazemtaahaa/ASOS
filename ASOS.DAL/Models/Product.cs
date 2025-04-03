namespace ASOS.DAL.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public Section? Section { get; set; }

        public decimal? Rate { get; set; }

        public int? Quantity { get; set; }

        public DateOnly? UpdatedAt { get; set; }

        public DateOnly? CreatedAt { get; set; }

        public decimal? Price { get; set; }

        public Guid BrandId { get; set; }

        public Brand Brand { get; set; }

        public Guid? CategoryId { get; set; }

        public Category Category { get; set; }

        public Guid? TypeId { get; set; }

        public Type Type { get; set; }

        public ICollection<ProductImages> ProductImages { get; set; } = new HashSet<ProductImages>();
    }
}
