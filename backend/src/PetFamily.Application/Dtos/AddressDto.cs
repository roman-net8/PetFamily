namespace PetFamily.Application.Dtos;

public record AddressDto(
    string Country, string City, 
    string Street, 
    string HouseNumber, 
    string AppartmentNumber);
