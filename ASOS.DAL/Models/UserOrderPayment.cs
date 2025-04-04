namespace ASOS.DAL.Models
{
    public class UserOrderPayment
    {
        public Guid Id { get; set; } 

        public Guid PaymentId { get; set; }

        public Payment? Payment { get; set; }

        public string UserId { get; set; }

        public User? User { get; set; }

        public Guid OrderId { get; set; }

        public Order? Order { get; set; }

    }
}
