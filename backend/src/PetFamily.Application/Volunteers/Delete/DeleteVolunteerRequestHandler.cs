using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using PetFamily.Domain.Models.Volunteers;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.Volunteers.Delete;

public class DeleteVolunteerRequestHandler
{
    private readonly IVolunteerRepository _repository;
    private readonly ILogger<DeleteVolunteerRequest> _logger;

    public DeleteVolunteerRequestHandler(
        IVolunteerRepository repository,
        ILogger<DeleteVolunteerRequest> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Result<Guid, Error>> Handle(
        DeleteVolunteerRequest request,
        CancellationToken cancellationToken = default)
    {
        var volunteerId = VolunteerId.Create(request.VolunteerId);

        var volunteerResult = await _repository.GetById(volunteerId, cancellationToken);

        if (volunteerResult.IsFailure)
            return Errors.General.NotFound(volunteerId.Value);

        var volunteer = volunteerResult;
        if (volunteer.IsFailure)
            return volunteer.Error;

        volunteer.Value.Delete();

        var id = await _repository.Save(volunteer.Value, cancellationToken);

        _logger.LogInformation("Volunteer {volunteerId} was soft deleted", volunteerId);

        return id;
    }
}
