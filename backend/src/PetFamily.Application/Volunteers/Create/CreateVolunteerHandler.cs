using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using PetFamily.Domain.Models.Volunteers;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.ValueObjects;

namespace PetFamily.Application.Volunteers.Create;
public class CreateVolunteerHandler
{
    private readonly IVolunteerRepository _volunteerRepository;
    private readonly ILogger<CreateVolunteerHandler> _logger;

    public CreateVolunteerHandler(
        IVolunteerRepository volunteersRepositories,
        ILogger<CreateVolunteerHandler> logger)
    {
        _volunteerRepository = volunteersRepositories;
        _logger = logger;
    }

    public async Task<Result<Guid, Error>> CreateVolunteer(
        CreateVolunteerCommand request, 
        CancellationToken cancellationToken)
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
            ).Value;

        var volunteer = Volunteer.Create
            (
                volunteerId,
                fullName,
                phoneNumber,
                email,
                description,
                request.YearsOfExperience,
                volunteerDetails
            );

        await _volunteerRepository.Add(volunteer.Value, cancellationToken);

        _logger.LogInformation("Created volunteer with ID: {id}", volunteerId);

        return (Guid)volunteer.Value.Id;
    }

}

