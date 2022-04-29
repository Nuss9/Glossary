using Common.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Validation.Attributes;

public class Monster : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is not Models.Monster monster)
        {
            ErrorMessage = "Invalid model";
            return false;
        }

        if (monster.Name == "Bob" && !monster.Birthday.IsAtLeastFiveHundredYearsOld())
        {
            ErrorMessage = "Monster Bob should be at least 500 years old";
            return false;
        }

        return true;
    }
}
