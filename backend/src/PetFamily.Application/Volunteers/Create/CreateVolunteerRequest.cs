using PetFamily.Application.Dtos; 

namespace PetFamily.Application.Volunteers.Create;

public record CreateVolunteerRequest(
    FullNameDto FullNameDto,
    EmailDto EmailDto,
    DescriptionDto DescriptionDto,
    decimal YearsOfExperience,
    PhoneNumberDto PhoneNumberDto,
    List<SocialNetworkDto>? SocialNetworkListDto,
    List<RequisiteDto>? RequisiteListDto,
    List<AddressDto>? AddresListDto);
 
 
