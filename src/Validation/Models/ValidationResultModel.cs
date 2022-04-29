using System.ComponentModel.DataAnnotations;

namespace Validation.Models;

public class ValidationResultModel
{
    public bool IsValid { get; set; }

    public IList<ValidationResult>? ValidationResults { get; set; }

    public override string ToString()
    {
        return $"{string.Join(", ", ValidationResults?.Select(result => result.ToString()) ?? Enumerable.Empty<string>())}";
    }
}
