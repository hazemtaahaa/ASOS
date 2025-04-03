namespace ASOS.DAL.Models
{
    public class Order 
    {
        public Guid Id { get; set; }

        public decimal TotalAmount { get; set; }

        public DateOnly Date { get; set; }

        public DateOnly ArrivalDate { get; set; }

        public OrderStatus Status { get; set; }

        //public Guid UserId { get; set; } 

        //public User User { get; set; }

        public UserOrderPayment UserOrderPayment { get; set; }

        public ICollection<OrderItems> OrderItems { get; set; } = new HashSet<OrderItems>();
    }

}
