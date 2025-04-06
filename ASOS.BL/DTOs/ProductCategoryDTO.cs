using System.ComponentModel.DataAnnotations;

namespace ASOS.BL.DTOs
{
    public class ProductCategoryDTO
    {
        public Guid Id { get; set; }
        
        public Guid ProductId { get; set; }
        
        public Guid CategoryId { get; set; }
        
        public string CategoryName { get; set; }
    }

    public class ProductCategoryCreateDTO
    {
        [Required]
        public Guid ProductId { get; set; }
        
        [Required]
        public Guid CategoryId { get; set; }
    }

    public class ProductCategoryUpdateDTO
    {
        public Guid CategoryId { get; set; }
    }
} 