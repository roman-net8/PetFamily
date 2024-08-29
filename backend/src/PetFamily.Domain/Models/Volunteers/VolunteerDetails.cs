using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models.Volunteers;
public record VolunteerDetails
{
    public IReadOnlyList<SocialNetwork> SocialNetworks { get; } = new List<SocialNetwork>();
    public IReadOnlyList<Requisite> Requisites { get; } = new List<Requisite>();
    public IReadOnlyList<Address> Addresses { get; } = new List<Address>();
}