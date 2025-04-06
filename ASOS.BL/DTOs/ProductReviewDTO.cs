using System.ComponentModel.DataAnnotations;

namespace ASOS.BL.DTOs
{
    public class ProductReviewDTO
    {
        public Guid Id { get; set; }
        
        public Guid ProductId { get; set; }
        
        public string UserId { get; set; }
        
        public string UserName { get; set; }
        
        public int Rating { get; set; }
        
        public string Comment { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }

    public class ProductReviewCreateDTO
    {
        [Required]
        public Guid ProductId { get; set; }
        
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
        
        [MaxLength(1000)]
        public string Comment { get; set; }
    }

    public class ProductReviewUpdateDTO
    {
        [Range(1, 5)]
        public int Rating { get; set; }
        
        [MaxLength(1000)]
        public string Comment { get; set; }
    }
} 