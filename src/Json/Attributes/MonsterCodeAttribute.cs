using System.ComponentModel.DataAnnotations;

namespace Json.Attributes;

public class MonsterCode : RegularExpressionAttribute
{
    public MonsterCode() : base("\\d{3}")
    {
        ErrorMessage = "Invalid Monster Code: should consist of 3 numbers";
    }
}
