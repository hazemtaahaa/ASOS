using System.ComponentModel.DataAnnotations;

namespace ASOS.DAL.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        public string? Description { get; set; }

        public Section Section { get; set; } 

        public decimal? Rate { get; set; }

        public int? Quantity { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public decimal? Price { get; set; }

        public Guid BrandId { get; set; }

        public Brand? Brand { get; set; }

        public Guid CategoryId { get; set; }

        public Category? Category { get; set; }

        public Guid ProductTypeId { get; set; }

        public ProductType? ProductType { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; } = new HashSet<ProductImage>();

        public ICollection<WishListProduct> WishListProducts { get; set; } = new HashSet<WishListProduct>();

        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();

        public ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
    }
}
