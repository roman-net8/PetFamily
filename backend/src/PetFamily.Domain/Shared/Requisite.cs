namespace PetFamily.Domain.Shared;

public record Requisite
{
    public string Title { get; private set; } = default!;
    public string Description { get; private set; } = default!;
}
