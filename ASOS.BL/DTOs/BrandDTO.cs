using System.ComponentModel.DataAnnotations;

namespace ASOS.BL.DTOs
{
    public class BrandDTO
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string BrandImage { get; set; }
    }

    public class BrandCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(500)]
        public string Description { get; set; }
        
        public string LogoUrl { get; set; }
    }

    public class BrandUpdateDTO
    {
        [MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(500)]
        public string Description { get; set; }
        
        public string LogoUrl { get; set; }
    }
} 