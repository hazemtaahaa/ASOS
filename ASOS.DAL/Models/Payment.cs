namespace ASOS.DAL.Models
{
    public class Payment
    {
        public Guid Id { get; set; }

        public DateOnly Date { get; set; }

        public PaymentStatus Status { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public Guid? StripPaymentId { get; set; }

        public decimal Amount { get; set; } 

        public UserOrderPayment UserOrderPayment { get; set; }

    }
}
