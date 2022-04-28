using Json.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using NUnit.Framework;
using System.Collections.Generic;

namespace Json.Tests;

public class MonsterJsonValidatorTests
{
    private readonly MonsterJsonValidator _subject;
    private readonly JSchema _monsterSchema;

    public MonsterJsonValidatorTests()
    {
        JSchemaGenerator generator = new();
        _monsterSchema = generator.Generate(typeof(Monster));

        _subject = new MonsterJsonValidator(_monsterSchema);
    }

    [Test]
    public void WhenUsingDefaultValidator_ItShouldReturnAppropriately()
    {
        // Arrange
        JObject monster = JObject.Parse(@"{
            'Name': 'Monster',
            'Legs': 4,
            'Type': 'Wraith',
            'Code': '123',
            'Birthday': '2018-03-19T00:00:00.000Z'
        }");

        IList<string> errorMessages;

        // Act
        bool isValid = monster.IsValid(_monsterSchema, out errorMessages);

        // Assert
        Assert.IsTrue(isValid);
        Assert.IsEmpty(errorMessages);
    }

    [Test]
    public void WhenUsingCustomValidator_ItShouldReturnAppropriately()
    {
        // Arrange
        JObject monster = JObject.Parse(@"{
            'Legs': '4',
            'Type': 'Cow', /* Does not yet get validated with the Attribute! */
            'Code': '1234',
            'Birthday': '2018-03-19'
        }");

        // Act
        var validationResult = _subject.ValidateMonsterData(monster);

        // Assert
        Assert.NotNull(validationResult);
        Assert.AreEqual(validationResult!.Count, 3);
    }
}
