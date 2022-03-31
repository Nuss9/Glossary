using Json.Models;
using System.ComponentModel.DataAnnotations;

namespace Json;

public static class ModelValidator
{
    public static ValidationResultModel Validate(object? obj)
    {
        if (obj == null)
        {
            return new ValidationResultModel
            {
                IsValid = false,
                ValidationResults = new List<ValidationResult>() {
                    new ValidationResult("Validator received null object")
                }
            };
        }

        var context = new ValidationContext(obj);
        var validationResults = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(obj, context, validationResults, true);

        return new ValidationResultModel
        {
            IsValid = isValid,
            ValidationResults = validationResults
        };
    }
}
