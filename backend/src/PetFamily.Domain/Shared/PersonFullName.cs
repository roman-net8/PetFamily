namespace PetFamily.Domain.Shared;

public record PersonFullName
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
}