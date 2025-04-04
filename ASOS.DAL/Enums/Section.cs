using System.Runtime.Serialization;

namespace ASOS.DAL;

public enum Section
{
    [EnumMember(Value = "Male")]
    Male = 0,
    [EnumMember(Value = "Female")]
    Female=1
}
