using PetFamily.Application.Dtos;

namespace PetFamily.Application.Volunteers.UpdateMainInfo;

public record UpdateMainInfoDto(
    FullNameDto FullName,
    string PhoneNumber,
    Decimal Experience,
    string Description);
