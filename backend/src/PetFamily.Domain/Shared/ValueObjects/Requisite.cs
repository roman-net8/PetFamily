using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared.ValueObjects;

public record Requisite
{
    private Requisite(
        string title,
        string description)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; } = default!;
    public string Description { get; } = default!;

    public static Result<Requisite, Error> Create(
        string title,
        string description)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Count() > Constants.MAX_TITLE_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("Requisite.title");
        }

        if (string.IsNullOrWhiteSpace(description) || description.Count() > Constants.MAX_DESCRIPTION_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("Requisite.description");
        }

        return new Requisite(title, description);
    }
}