using System.ComponentModel.DataAnnotations;

namespace ASOS.BL.DTOs
{
    public class ProductTypeDTO
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
    }

    public class ProductTypeCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(500)]
        public string Description { get; set; }
    }

    public class ProductTypeUpdateDTO
    {
        [MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(500)]
        public string Description { get; set; }
    }
} 