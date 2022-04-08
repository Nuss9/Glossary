using Json.Models;
using NUnit.Framework;

namespace Json.Tests2
{
    public class ModelValidatorTests
    {
        [Test]
        public void WhenModelIsNull_ItShouldThrow()
        {
            // Arrange
            Monster monster = null!;

            // Act
            var validationResult = ModelValidator.Validate(monster);

            // Assert
            Assert.False(validationResult.IsValid);
            //Assert.Equal(validationResult.ValidationResults.Single().ErrorMessage, "Validator received null object");
        }
    }
}