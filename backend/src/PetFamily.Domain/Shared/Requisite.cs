namespace PetFamily.Domain.Shared;

public record Requisite
{
    private Requisite()
    {
    }

    private Requisite(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; private set; } = default!;
    public string Description { get; private set; } = default!;
}