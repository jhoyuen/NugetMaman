using NugetGitHub.Common.Extensions;

namespace NugetGitHub.Common.Tests.Extensions;

public class StringEmailExtensionsTests
{
    [Theory]
    [InlineData("jon_lg92@yahoo.com")]
    [InlineData("testuser@mailinator.com")]
    [InlineData("Mary.Poppins@mecca.com.au")]
    public void IsValidEmail_WhenEmailValid_ShouldReturnEmailValidationResult_Valid(string email)
    {
        // Arrange
        var expected = StringEmailExtensions.EmailValidationResult.Valid;
        // Act
        var result = email.IsValidEmail();
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData(null)]
    public void IsValidEmail_WhenEmailEmptyOrNull_ShouldReturnEmailValidationResult_EmptyOrWhitespace(string email)
    {
        // Arrange
        var expected = StringEmailExtensions.EmailValidationResult.EmptyOrWhitespace;
        // Act
        var result = email.IsValidEmail();
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("jon_lg92")]
    [InlineData("jon_lg92@")]
    [InlineData("@yahoo.com")]
    public void IsValidEmail_WhenEmailFormatIsInvalid_ShouldReturnEmailValidationResult_InvalidFormat(string email)
    {
        // Arrange
        var expected = StringEmailExtensions.EmailValidationResult.InvalidFormat;
        // Act
        var result = email.IsValidEmail();
        // Assert
        Assert.Equal(expected, result);
    }
}
