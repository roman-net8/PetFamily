using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models.Volunteers;
public record VolunteerDetails
{
    private readonly List<SocialNetwork> _socialNetworks = [];
    private readonly List<Requisite> _requisites = [];

    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;
    public IReadOnlyList<Requisite> Requisites => _requisites;
}