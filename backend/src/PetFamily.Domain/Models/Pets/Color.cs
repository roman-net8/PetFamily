using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models.Pets;

public record Color
{
    private Color(string value) => Value = value;

    public string Value { get; } = default!;

    public static Result<Color, Error> Create(string color)
    {
        if (string.IsNullOrWhiteSpace(color) || color.Length > Constants.MAX_PET_COLOR_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("Color");
        }

        return new Color(color);
    }
}



