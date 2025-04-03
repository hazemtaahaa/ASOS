namespace ASOS.DAL.Models
{
    public class Payment
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public PaymentStatus Status { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public Guid? StripPaymentId { get; set; }

        public decimal Amount { get; set; }

        public ICollection<UserOrderPayment> UserOrderPayments { get; set; } = new HashSet<UserOrderPayment>();


    }
}
