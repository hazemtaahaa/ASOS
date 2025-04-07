using System.ComponentModel.DataAnnotations;

namespace ASOS.BL.DTOs
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        
    }

    public class CategoryCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(500)]
        public string Description { get; set; }
        
        public string ImageUrl { get; set; }
    }

    public class CategoryUpdateDTO
    {
        [MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(500)]
        public string Description { get; set; }
        
        public string ImageUrl { get; set; }
    }
} 