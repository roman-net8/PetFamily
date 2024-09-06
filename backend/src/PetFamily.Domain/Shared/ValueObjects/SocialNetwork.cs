using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared.ValueObjects;

public record SocialNetwork
{
    public string UserName { get; private set; } = default!;
    public string Link { get; private set; } = default!;
    public string Description { get; private set; } = default!;

    private SocialNetwork(string userName, string link, string description)
    {
        UserName = userName;
        Link = link;
        Description = description;
    }

    public static Result<SocialNetwork, Error> Create(string userName, string link, string description)
    {
        if (string.IsNullOrWhiteSpace(userName) || userName.Length > Constants.MAX_NAME_TEXT_LENGTH)
            return Errors.General.ValueIsInvalid("SocialNetwork.userName");

        if (string.IsNullOrWhiteSpace(link) || link.Length > Constants.MAX_LINK_TEXT_LENGTH)
            return Errors.General.ValueIsInvalid("SocialNetwork.link");

        if (string.IsNullOrWhiteSpace(description) || description.Length > Constants.MAX_DESCRIPTION_TEXT_LENGTH)
            return Errors.General.ValueIsInvalid("SocialNetwork.description");

        return new SocialNetwork(userName, link, description);
    }
}
