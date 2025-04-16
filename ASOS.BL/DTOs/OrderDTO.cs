using ASOS.DAL;
using System.ComponentModel.DataAnnotations;

namespace ASOS.BL.DTOs
{
    public class OrderDTO
    {
        public Guid Id { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime Date { get; set; }

        public DateTime ArrivalDate { get; set; }

        public OrderStatus Status { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string UserId { get; set; }

        public ICollection<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();

        public PaymentDTO Payment { get; set; }
    }

    public class OrderCreateDTO
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public ICollection<OrderItemCreateDTO> OrderItems { get; set; } = new List<OrderItemCreateDTO>();

        [Required]
        public PaymentCreateDTO Payment { get; set; }
    }

    public class OrderUpdateDTO
    {
        public OrderStatus Status { get; set; }

        public DateTime ArrivalDate { get; set; }
    }

    public class OrderItemDTO
    {

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public List<string> ImageUrls { get; set; } = new List<string>();
    }

    public class OrderItemCreateDTO
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}