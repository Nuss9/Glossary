using Common;
using Common.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Json.Attributes;

public class MonsterType : ValidationAttribute
{
    public MonsterType()
    {
        ErrorMessage = "Invalid monster type";
    }

    public override bool IsValid(object? value)
        => value is string type && type.In(Constants.MonsterTypes.Split(','));
}
