namespace ASOS.DAL.Models
{
    public class Payment
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public PaymentStatus? Status { get; set; }

        public PaymentMethod? PaymentMethod { get; set; }

        public string? StripPaymentId { get; set; }

        public decimal? Amount { get; set; }

        public UserOrderPayment UserOrderPayment { get; set; }

    }
}
