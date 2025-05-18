using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace NugetGitHub.Common.Extensions;

public static class StringEmailExtensions
{
    public static EmailValidationResult IsValidEmail(this string email)
    {
        return email switch
        {
            null => EmailValidationResult.EmptyOrWhitespace,
            { } s when string.IsNullOrEmpty(s) => EmailValidationResult.EmptyOrWhitespace,
            { } s when string.IsNullOrWhiteSpace(s) => EmailValidationResult.EmptyOrWhitespace,
            { } s when !new EmailAddressAttribute().IsValid(s) => EmailValidationResult.InvalidFormat,
            { } s => ValidateMailAddress(s)
        };
    }

    private static EmailValidationResult ValidateMailAddress(string email)
    {
        try
        {
            _ = new MailAddress(email);
            return EmailValidationResult.Valid;
        }
        catch
        {
            return EmailValidationResult.UnknownError;
        }
    }

    public enum EmailValidationResult
    {
        Valid,
        EmptyOrWhitespace,
        InvalidFormat,
        UnknownError
    }

}
