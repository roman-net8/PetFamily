using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using PetFamily.Domain.Models.Volunteers;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.ValueObjects;

namespace PetFamily.Application.Volunteers.UpdateMainInfo;

public class UpdateMainInfoHandler
{
    private readonly IVolunteerRepository _repository;
    private readonly ILogger<UpdateMainInfoRequest> _logger;

    public UpdateMainInfoHandler(
        IVolunteerRepository repository,
        ILogger<UpdateMainInfoRequest> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Result<Guid, Error>> Handle(
        UpdateMainInfoRequest request,
        CancellationToken cancellationToken = default)
    {
        var volunteerId = VolunteerId.Create(request.VolunteerId);

        var volunteerResult = await _repository.GetById(volunteerId, cancellationToken);

        if (volunteerResult.IsFailure)
            return volunteerResult.Error;

        var volunteer = volunteerResult.Value;

        var fullName = FullName.Create(
            request.Dto.FullName.FirstName,
            request.Dto.FullName.MiddleName,
            request.Dto.FullName.LastName);
        if (fullName.IsFailure)
            return fullName.Error;

        var phoneNumber = PhoneNumber.Create(request.Dto.PhoneNumber);
        if (phoneNumber.IsFailure)
            return phoneNumber.Error;

        var experience = request.Dto.Experience;
        if (experience < 0)
            return Errors.General.ValueIsInvalid("Experience");

        var description = Description.Create(request.Dto.Description);
        if (description.IsFailure)
            return description.Error;

        volunteer.UpdateMainInfo(fullName.Value, description.Value, experience, phoneNumber.Value);

        var id = await _repository.Save(volunteer, cancellationToken);

        _logger.LogInformation("Volunteer {id} updated", id);

        return id;
    }
}
