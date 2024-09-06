using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.ValueObjects;

namespace PetFamily.Domain.Models.Volunteers;
public record VolunteerDetails
{
    private VolunteerDetails()
    {
    }

    private VolunteerDetails(
        List<SocialNetwork> socialNetworks,
        List<Requisite> requisites,
        List<Address> addresses)
    {
        SocialNetworks = socialNetworks;
        Requisites = requisites;
        Addresses = addresses;
    }

    public IReadOnlyList<SocialNetwork> SocialNetworks { get; } = new List<SocialNetwork>();
    public IReadOnlyList<Requisite> Requisites { get; } = new List<Requisite>();
    public IReadOnlyList<Address> Addresses { get; } = new List<Address>();

    public static Result<VolunteerDetails, Error> Create(
        List<SocialNetwork> socialNetworks,
        List<Requisite> requisites,
        List<Address> addresses)
    {
        return new VolunteerDetails(socialNetworks, requisites, addresses);
    }
}