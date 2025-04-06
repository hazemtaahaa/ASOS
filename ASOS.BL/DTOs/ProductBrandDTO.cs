using System.ComponentModel.DataAnnotations;

namespace ASOS.BL.DTOs
{
    public class ProductBrandDTO
    {
        public Guid Id { get; set; }
        
        public Guid ProductId { get; set; }
        
        public Guid BrandId { get; set; }
        
        public string BrandName { get; set; }
    }

    public class ProductBrandCreateDTO
    {
        [Required]
        public Guid ProductId { get; set; }
        
        [Required]
        public Guid BrandId { get; set; }
    }

    public class ProductBrandUpdateDTO
    {
        public Guid BrandId { get; set; }
    }
} 