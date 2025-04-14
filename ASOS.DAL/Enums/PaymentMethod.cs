using System.Runtime.Serialization;

namespace ASOS.DAL;

public enum PaymentMethod
{
    [EnumMember(Value = "Cash")]
    Card = 1,
    [EnumMember(Value = "Card")]
    Cash = 0,

}
