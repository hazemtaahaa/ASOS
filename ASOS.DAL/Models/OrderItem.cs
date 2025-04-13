using System.ComponentModel.DataAnnotations.Schema;

namespace ASOS.DAL.Models
{
    public class OrderItem
    {
        public Guid ProductId { get; set; }

        public Product? Product { get; set; }

        public Guid OrderId { get; set; }

        public Order? Order { get; set; }

        public int? Quantity { get; set; }

        public decimal? TotalPrice { get; set; }
    }
}
