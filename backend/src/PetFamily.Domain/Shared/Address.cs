namespace PetFamily.Domain.Shared;

public record Address
{
    private Address(string country, string city, string street, string houseNumber, string appartmentNumber)
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
}