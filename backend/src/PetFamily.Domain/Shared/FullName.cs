namespace PetFamily.Domain.Shared;

public record FullName
{
    public string FirstName { get; private set; } = default!;
    public string MiddleName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
}