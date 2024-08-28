using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models.Volunteers;
public record VolunteerDetails
{
    private readonly List<SocialNetwork> _socialNetworks = [];
    private readonly List<Requisite> _requisites = [];
    private readonly List<Address> _address = [];

    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;
    public IReadOnlyList<Requisite> Requisites => _requisites;
    public IReadOnlyList<Address> Addresses => _address;
}