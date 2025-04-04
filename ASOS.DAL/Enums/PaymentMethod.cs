using System.Runtime.Serialization;

namespace ASOS.DAL;

public enum PaymentMethod
{
    [EnumMember(Value = "Cash")]
    Cash = 0,
    [EnumMember(Value = "Card")]
    Card = 1,

}
