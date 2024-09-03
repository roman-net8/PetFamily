using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared.ValueObjects;

public record Address
{
    private Address(
        string country,
        string city,
        string street,
        string houseNumber,
        string appartmentNumber)
    {
        Country = country;
        City = city;
        Street = street;
        HouseNumber = houseNumber;
        AppartmentNumber = appartmentNumber;
    }

    public string Country { get; } = default!;
    public string City { get; } = default!;
    public string Street { get; } = default!;
    public string HouseNumber { get; } = default!;
    public string AppartmentNumber { get; } = default!;

    public static Result<Address, Error> Create(
        string country,
        string city,
        string street,
        string house,
        string appartment)
    {
        if (string.IsNullOrWhiteSpace(country) || country.Count() > Constants.MAX_ADDRESS_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("Address.Country");
        }

        if (string.IsNullOrWhiteSpace(city) || city.Count() > Constants.MAX_ADDRESS_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("Address.City");
        }

        if (string.IsNullOrWhiteSpace(street) || street.Count() > Constants.MAX_ADDRESS_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("Address.Street");
        }

        if (string.IsNullOrWhiteSpace(house) || house.Count() > Constants.MIN_ADDRESS_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("Address.House");
        }

        if (string.IsNullOrWhiteSpace(appartment) || appartment.Count() > Constants.MIN_ADDRESS_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("Address.Appartment");
        }

        return new Address(country, city, street, house, appartment);
    }
}