using System.ComponentModel.DataAnnotations;

namespace ASOS.BL.DTOs
{
    public class ProductColorDTO
    {
        public Guid Id { get; set; }
        
        public Guid ProductId { get; set; }
        
        public string Color { get; set; }
        
        public string ColorCode { get; set; }
        
        public int Quantity { get; set; }
    }

    public class ProductColorCreateDTO
    {
        [Required]
        public Guid ProductId { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Color { get; set; }
        
        [Required]
        [MaxLength(10)]
        public string ColorCode { get; set; }
        
        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }

    public class ProductColorUpdateDTO
    {
        [MaxLength(50)]
        public string Color { get; set; }
        
        [MaxLength(10)]
        public string ColorCode { get; set; }
        
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
} 