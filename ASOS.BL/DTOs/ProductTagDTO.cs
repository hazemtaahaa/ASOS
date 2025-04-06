using System.ComponentModel.DataAnnotations;

namespace ASOS.BL.DTOs
{
    public class ProductTagDTO
    {
        public Guid Id { get; set; }
        
        public Guid ProductId { get; set; }
        
        public string Tag { get; set; }
    }

    public class ProductTagCreateDTO
    {
        [Required]
        public Guid ProductId { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Tag { get; set; }
    }

    public class ProductTagUpdateDTO
    {
        [MaxLength(50)]
        public string Tag { get; set; }
    }
} 