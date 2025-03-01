using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared.ValueObjects;

public record YearsExperience
{
    public decimal Value { get; }

    private YearsExperience(decimal value)
    {
        Value = value;
    }

    public static Result<YearsExperience, Error> Create(decimal value)
    {
        if (decimal.IsNegative(value) || value > 50)
        {
            return Result.Failure<YearsExperience, Error>(Errors.General.ValueIsInvalid(value.ToString() + "YearsExperience"));
        }

        return new YearsExperience(value);
    }
}
