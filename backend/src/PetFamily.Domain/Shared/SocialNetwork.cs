namespace PetFamily.Domain.Shared;

public record SocialNetwork
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string Link { get; private set; } = default!;
    public string Description { get; private set; } = default!;
}
