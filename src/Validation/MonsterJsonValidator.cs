using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.ComponentModel.DataAnnotations;

namespace Validation;

public class MonsterJsonValidator
{
    private readonly JSchema _monsterValidationSchema;

    public MonsterJsonValidator(JSchema profileValidationSchema)
    {
        _monsterValidationSchema = profileValidationSchema;
    }

    public IList<ValidationResult>? ValidateMonsterData(JObject monsterData)
    {
        var monsterObject = JObject.FromObject(monsterData);

        if (!monsterObject.IsValid(_monsterValidationSchema, out IList<string> errorMessages))
        {
            var validationResult = new List<ValidationResult>();
            errorMessages.ToList().ForEach(errorMessage => validationResult.Add(new ValidationResult(errorMessage)));

            return validationResult;
        }

        return null;
    }
}
