using System.ComponentModel.DataAnnotations;

namespace ASOS.BL.DTOs
{
    public class WishListDTO
    {
        public Guid Id { get; set; }
        
        public string UserId { get; set; }
        
        public ICollection<WishListItemDTO> WishListItems { get; set; } = new List<WishListItemDTO>();
    }

    public class WishListItemDTO
    {
        public Guid Id { get; set; }
        
        public Guid ProductId { get; set; }
        
        public string ProductName { get; set; }
        
        public decimal ProductPrice { get; set; }
        
        public string ProductImage { get; set; }
    }

    public class WishListItemCreateDTO
    {
        [Required]
        public Guid ProductId { get; set; }
    }
} 