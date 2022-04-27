using Json.Models;
using NUnit.Framework;
using System;

namespace Json.Tests;

public class ModelValidatorTests
{
    [Test]
    public void WhenValidatorGetsNullObject_ItShouldReturnInvalid()
    {
        // Arrange
        Monster monster = null!;

        // Act
        var validationResult = ModelValidator.Validate(monster);

        // Assert
        Assert.False(validationResult.IsValid);
    }

    [Test]
    public void WhenStringIsRequired_ItShouldNotAcceptTheseValues()
    {
        // Arrange
        Monster monster0 = new() { Name = default!, Legs = 4 };
        Monster monster1 = new() { Name = null!, Legs = 4 };
        Monster monster2 = new() { Name = "", Legs = 4 };
        Monster monster3 = new() { Name = " ", Legs = 4 };
        Monster monster4 = new() { Name = string.Empty, Legs = 4 };

        // Act & Assert
        var validationResult0 = ModelValidator.Validate(monster0);
        var validationResult1 = ModelValidator.Validate(monster1);
        var validationResult2 = ModelValidator.Validate(monster2);
        var validationResult3 = ModelValidator.Validate(monster3);
        var validationResult4 = ModelValidator.Validate(monster4);

        // Assert
        Assert.IsFalse(validationResult0.IsValid);
        Assert.IsFalse(validationResult1.IsValid);
        Assert.IsFalse(validationResult2.IsValid);
        Assert.IsFalse(validationResult3.IsValid);
        Assert.IsFalse(validationResult4.IsValid);
    }

    [TestCase(default)]
    [TestCase(100)]
    public void WhenIntHasRange_ItShouldAcceptIntsWithinRange(int amount)
    {
        // Arrange
        Monster monster = new() { Name = "Monster", Legs = amount, Type = "Basilisk"};

        // Act
        var validationResult = ModelValidator.Validate(monster);

        //Assert
        Assert.IsTrue(validationResult.IsValid);
    }

    [TestCase("Basilisk", true)]
    [TestCase("Vampire", false)]
    [TestCase( null, false)]
    public void WhenStringIsPredefinedOption_ItShouldValidateAccordingly(string type, bool expected)
    {
        // Arrange
        Monster monster = new() { Name = "Monster", Legs = 4, Type = type };

        // Act
        var validationResult = ModelValidator.Validate(monster);

        // Assert
        Assert.AreEqual(validationResult.IsValid, expected);
    }

    [TestCase("123", true)]
    [TestCase("1234", false)]
    [TestCase("MON", false)]
    public void WhenStringIsRegexValidated_ItShouldValidateAccordingly(string code, bool expected)
    {
        // Arrange
        Monster monster = new() { Name = "Monster", Legs = 4, Type = "Basilisk", Code = code };

        // Act
        var validationResult = ModelValidator.Validate(monster);

        // Assert
        Assert.AreEqual(validationResult.IsValid, expected);
    }

    [TestCase(-500, true)]
    [TestCase(-499, false)]
    public void WhenUsingClassAttribute_ItShouldValidateOnClassLevel(int ageInYears, bool expected)
    {
        // Arrange
        var birthday = DateTime.Now.AddYears(ageInYears);

        Monster monster = new() { Name = "Bob", Legs = default, Type = "Wyvern", Code = "123", Birthday = birthday };

        // Act
        var validationResult = ModelValidator.Validate(monster);

        // Assert
        Assert.AreEqual(validationResult.IsValid, expected);
    }
}
