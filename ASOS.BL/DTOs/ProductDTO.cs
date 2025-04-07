using ASOS.DAL;
using System.ComponentModel.DataAnnotations;

namespace ASOS.BL.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        public decimal Rate { get; set; }
        
        public int Quantity { get; set; }
        
        public Section Section { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public string BrandName { get; set; }

        public string CategoryName { get; set; }
        
        public string ProductTypeName { get; set; }
        
        public ICollection<string> ImageUrls { get; set; } = new List<string>();
    }

    public class ProductCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        public int Quantity { get; set; }
        
        public Section Section { get; set; }
        
        public Guid BrandId { get; set; }
        
        public Guid CategoryId { get; set; }
        
        public Guid ProductTypeId { get; set; }
        
        public ICollection<string> ImageUrls { get; set; } = new List<string>();
    }

    public class ProductUpdateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        public int Quantity { get; set; }
        
        public Section Section { get; set; }
        
        public Guid BrandId { get; set; }
        
        public Guid CategoryId { get; set; }
        
        public Guid ProductTypeId { get; set; }
        
        public ICollection<string> ImageUrls { get; set; } = new List<string>();
    }
} 