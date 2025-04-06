using System.ComponentModel.DataAnnotations;

namespace ASOS.BL.DTOs
{
    public class ProductDiscountDTO
    {
        public Guid Id { get; set; }
        
        public Guid ProductId { get; set; }
        
        public decimal DiscountPercentage { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
    }

    public class ProductDiscountCreateDTO
    {
        [Required]
        public Guid ProductId { get; set; }
        
        [Required]
        [Range(0, 100)]
        public decimal DiscountPercentage { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime EndDate { get; set; }
    }

    public class ProductDiscountUpdateDTO
    {
        [Range(0, 100)]
        public decimal DiscountPercentage { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
    }
} 