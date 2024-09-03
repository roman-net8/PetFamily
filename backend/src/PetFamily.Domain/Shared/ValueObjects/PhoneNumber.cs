using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace PetFamily.Domain.Shared.ValueObjects;

public record PhoneNumber
{
    private const string PHONE_REGEX = @"^\+380(\d{2}\d{3}\d{4}|\d{2}[ -]?\d{3}[ -]?\d{4})$";

    private PhoneNumber(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<PhoneNumber, Error> Create(string phone)
    {
        phone = phone.Trim();

        if (!Regex.IsMatch(phone.Trim(), PHONE_REGEX))
        {
            return Errors.General.ValueIsInvalid("Phone");
        }

        return new PhoneNumber(phone);
    }
};
