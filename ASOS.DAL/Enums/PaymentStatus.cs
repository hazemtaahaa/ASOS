using System.Runtime.Serialization;

namespace ASOS.DAL;
public enum PaymentStatus
{
    [EnumMember(Value = "Pending")]
    Pending = 0,
    [EnumMember(Value = "Approved")]
    Approved = 1,
    [EnumMember(Value = "Rejected")]
    Rejected = 2
}

