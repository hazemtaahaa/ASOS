namespace ASOS.DAL.Models
{
    public class Order 
    {
        public Guid Id { get; set; }

        public decimal? TotalAmount { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public DateTime ArrivalDate { get; set; } = DateTime.Now.AddDays(7);

        public OrderStatus Status { get; set; }

        public UserOrderPayment? UserOrderPayment { get; set; } 

        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
    }

}
