namespace ASOS.DAL.Models
{
    public class OrderItems
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public Guid OrderId { get; set; }

        public Order Order { get; set; }

        public int Quantity { get; set; }
    }
}
