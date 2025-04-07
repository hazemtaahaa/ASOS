using ASOS.DAL;
using System.ComponentModel.DataAnnotations;

namespace ASOS.BL.DTOs
{
    public class PaymentDTO
    {
        public Guid Id { get; set; }
        
        public DateTime Date { get; set; }
        
        public PaymentStatus Status { get; set; }
        
        public PaymentMethod PaymentMethod { get; set; }
        
        public Guid? StripPaymentId { get; set; }
        
        public decimal Amount { get; set; }
        
        public string UserId { get; set; }
        
        public Guid OrderId { get; set; }
    }

    public class PaymentCreateDTO
    {
        [Required]
        public PaymentMethod PaymentMethod { get; set; }
        
        [Required]
        public decimal Amount { get; set; }
        
        [Required]
        public string UserId { get; set; }
        
        [Required]
        public Guid OrderId { get; set; }
    }

    public class PaymentUpdateDTO
    {
        public PaymentStatus Status { get; set; }
        
        public Guid? StripPaymentId { get; set; }
    }
} 