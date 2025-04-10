using System.ComponentModel.DataAnnotations;

namespace ASOS.BL.DTOs
{
    public class CartDTO
    {
        public Guid Id { get; set; }
        
        public string UserId { get; set; }


        public string? PaymentIntentId { get; set; }

        public string? ClientSecrete { get; set; } 


        public ICollection<CartItemDTO> CartItems { get; set; } = new List<CartItemDTO>();
        
        public decimal TotalAmount { get; set; }
    }

    public class CartItemDTO
    {
        public Guid Id { get; set; }
        
        public Guid ProductId { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal Price { get; set; }
        
        public string ProductName { get; set; }
        
        public string ProductImage { get; set; }
    }

    public class CartItemCreateDTO
    {
        [Required]
        public Guid ProductId { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }

    public class CartItemUpdateDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
} 