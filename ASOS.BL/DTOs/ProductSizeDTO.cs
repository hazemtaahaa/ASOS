using System.ComponentModel.DataAnnotations;

namespace ASOS.BL.DTOs
{
    public class ProductSizeDTO
    {
        public Guid Id { get; set; }
        
        public Guid ProductId { get; set; }
        
        public string Size { get; set; }
        
        public int Quantity { get; set; }
    }

    public class ProductSizeCreateDTO
    {
        [Required]
        public Guid ProductId { get; set; }
        
        [Required]
        [MaxLength(10)]
        public string Size { get; set; }
        
        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }

    public class ProductSizeUpdateDTO
    {
        [MaxLength(10)]
        public string Size { get; set; }
        
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
} 