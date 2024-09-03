using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace PetFamily.Domain.Shared.ValueObjects;

public record Email
{
    public const string EMAIL_REGULAR_EXPR
        = @"^[-\w.]+@([A-z0-9][-A-z0-9]+\.)+[A-z]{2,4}$";

    private Email(string value)
    {
        Value = value;
    }

    public string Value { get; } = default!;

    public static Result<Email, Error> Create(string email)
    {
        email = email.Trim();

        if (string.IsNullOrWhiteSpace(email))
        {
            return Errors.General.ValueIsEmpty("Email");
        }

        if (!Regex.IsMatch(email, EMAIL_REGULAR_EXPR))
        {
            return Errors.General.ValueIsInvalid("Email");
        }

        return new Email(email);
    }
}
