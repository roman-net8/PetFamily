using PetFamily.Application.Dtos;

namespace PetFamily.Application.Volunteers.UpdateSocialNetworks;

public record UpdateSocialNetworksDto(IEnumerable<SocialNetworkDto> SocialNetworks);