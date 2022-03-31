using Json.Models;
using Xunit;

namespace Json.Tests;

public class ModelValidatorTests
{
    [Fact]
    public void WhenModelIsNull_ItShouldThrow()
    {
        // Arrange
        Monster monster = null!;

        // Act
        var validationResult = ModelValidator.Validate(monster);

        // Assert
        Assert.False(validationResult.IsValid);
        Assert.Equal(validationResult.ValidationResults.Single().ErrorMessage, "Validator received null object");
    }
}
