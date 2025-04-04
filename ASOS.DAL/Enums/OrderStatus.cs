using System.Runtime.Serialization;

namespace ASOS.DAL;


public enum OrderStatus
{
    // Basic statuses
    [EnumMember(Value = "Pending")]
    Pending = 0,          // Order created but not processed
    [EnumMember(Value = "Processing")]
    Processing = 1,       // Payment confirmed, preparing for shipment
    [EnumMember(Value = "Shipped")]
    Shipped = 2,          // Order dispatched to customer
    [EnumMember(Value = "Delivered")]
    Delivered = 3,        // Order received by customer
    [EnumMember(Value = "Cancelled")]
    Cancelled = 4,        // Order cancelled before shipping
    [EnumMember(Value = "Returned")]
    Returned = 5,         // Order returned by customer

}
