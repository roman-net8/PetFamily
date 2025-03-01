using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using PetFamily.Domain.Models.Volunteers;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.ValueObjects;

namespace PetFamily.Application.Volunteers.UpdateRequisites;

public sealed class UpdateRequisitesHandler
{
    private readonly IVolunteerRepository _requisitesRepository;
    private readonly ILogger<UpdateRequisitesRequest> _logger;

    public UpdateRequisitesHandler(
        IVolunteerRepository repository,
        ILogger<UpdateRequisitesRequest> logger)
    {
        _requisitesRepository = repository;
        _logger = logger;
    }

    public async Task<Result<Guid, Error>> Handle(
        UpdateRequisitesRequest request,
        CancellationToken cancellationToken)
    {
        var volunteerId = VolunteerId.Create(request.VolunteerId);

        var volunteerResult = await _requisitesRepository.GetById(volunteerId, cancellationToken);

        if (volunteerResult.IsFailure)
            return volunteerResult.Error;

        Volunteer? volunteer = volunteerResult.Value;

        var volunteerRequisites = request.Dto.Requisites
             .Select(r => Requisite.Create(r.Title, r.Description));
         
        if (volunteerRequisites.Any(r => r.IsFailure))
            return Result.Failure<Guid, Error>(volunteerRequisites.First(r => r.IsFailure).Error);   
         
        volunteer.Details.UpdateRequisites(
            volunteerRequisites.Select(r=>r.Value).ToList());

        var id = await _requisitesRepository.Save(volunteer, cancellationToken);

        _logger.LogInformation("Requisites for volunteer {id} updated", id);

        return id;
    }
}
