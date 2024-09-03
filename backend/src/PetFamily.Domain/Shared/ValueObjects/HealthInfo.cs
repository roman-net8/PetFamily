using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared.ValueObjects;

public record HealthInfo
{
    private HealthInfo(string value)
    {
        Value = value;
    }

    public string Value { get; } = default!;

    public static Result<HealthInfo, Error> Create(string healthInfo)
    {
        if (string.IsNullOrWhiteSpace(healthInfo) || healthInfo.Length > Constants.MAX_PET_HEALTH_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("HealthInfo");
        }

        return new HealthInfo(healthInfo);
    }
};