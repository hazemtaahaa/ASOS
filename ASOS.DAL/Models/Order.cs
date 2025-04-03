namespace ASOS.DAL.Models
{
    public class Order 
    {
        public Guid Id { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime Date { get; set; }

        public DateTime ArrivalDate { get; set; }

        public OrderStatus Status { get; set; }

        //public Guid UserId { get; set; } 

        //public User User { get; set; }

        public ICollection<UserOrderPayment> UserOrderPayments { get; set; } = new HashSet<UserOrderPayment>();

        public ICollection<OrderItems> OrderItems { get; set; } = new HashSet<OrderItems>();
    }

}
