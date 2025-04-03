namespace ASOS.DAL;

public enum OrderStatus
{
    // Basic statuses
    Pending = 0,          // Order created but not processed
    Processing = 1,       // Payment confirmed, preparing for shipment
    Shipped = 2,          // Order dispatched to customer
    Delivered = 3,        // Order received by customer
    Cancelled = 4,        // Order cancelled before shipping
    Returned = 5,         // Order returned by customer

    // Additional statuses (optional)
    OnHold = 6,           // Requires manual review
    PaymentPending = 7,   // Awaiting payment confirmation
    PaymentFailed = 8,    // Payment processing failed
    Refunded = 9          // Payment refunded to customer
}
