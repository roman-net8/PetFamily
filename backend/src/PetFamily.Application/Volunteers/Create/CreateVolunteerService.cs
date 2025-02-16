using CSharpFunctionalExtensions;
using PetFamily.Domain.Models.Volunteers;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.ValueObjects;

namespace PetFamily.Application.Volunteers.Create;
public class CreateVolunteerService
{
    private readonly IVolunteersRepository _volunteersRepositories;

    public CreateVolunteerService(IVolunteersRepository volunteersRepositories)
    {
        _volunteersRepositories = volunteersRepositories;
    }

    public async Task<Result<Guid, Error>> Create(
        CreateVolunteerCommand request, CancellationToken cancellationToken)
    {
        var volunteerId = VolunteerId.NewId();

        var fullName = FullName.Create(
            request.FullNameDto.FirstName,
            request.FullNameDto.MiddleName,
            request.FullNameDto.LastName).Value;

        var phoneNumber = PhoneNumber.Create(
            request.PhoneNumberDto.PhoneNumber).Value;

        var email = Email.Create(
            request.EmailDto.Value).Value;

        var description = Description.Create(
      request.DescriptionDto.Value).Value;

        var socialNetworks = request.SocialNetworkListDto?
            .Select(s => SocialNetwork.Create(s.UserName, s.Description, s.Link).Value).ToList()
             ?? new List<SocialNetwork>();

        var requisites = request.RequisiteListDto?
            .Select(r => Requisite.Create(r.Title, r.Description).Value).ToList()
             ?? new List<Requisite>();

        var addresses = request.AddresListDto?
            .Select(a => Address.Create(a.Country, a.City, a.Street, a.HouseNumber, a.AppartmentNumber).Value).ToList()
            ?? new List<Address>();

        var volunteerDetails = VolunteerDetails.Create(
            socialNetworks,
            requisites,
            addresses
            );

        var volunteer = Volunteer.Create
            (
                volunteerId,
                fullName,
                phoneNumber,
                email,
                description,
                request.YearsOfExperience,
                volunteerDetails.Value
            );

        await _volunteersRepositories.Add(volunteer.Value, cancellationToken);

        return volunteerId.Value;
    }

}

