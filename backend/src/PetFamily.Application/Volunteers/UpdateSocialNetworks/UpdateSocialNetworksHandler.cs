using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using PetFamily.Domain.Models.Volunteers;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.ValueObjects;

namespace PetFamily.Application.Volunteers.UpdateSocialNetworks;

public sealed class UpdateSocialNetworksHandler
{
    private readonly IVolunteerRepository _repository;
    private readonly ILogger<UpdateSocialNetworksRequest> _logger;

    public UpdateSocialNetworksHandler(
        IVolunteerRepository repository,
        ILogger<UpdateSocialNetworksRequest> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Result<Guid, Error>> Handle(
        UpdateSocialNetworksRequest request,
        CancellationToken cancellationToken = default)
    {
        var volunteerId = VolunteerId.Create(request.VolunteerId);

        var volunteerResult = await _repository.GetById(volunteerId, cancellationToken);

        if (volunteerResult.IsFailure)
            return volunteerResult.Error;

        var volunteer = volunteerResult.Value;

        var socialNetworks = request.Dto.SocialNetworks
            .Select(s => SocialNetwork.Create(s.UserName, s.Link, s.Description));

        if (socialNetworks.Any(s => s.IsFailure))
            return Result.Failure<Guid, Error>(socialNetworks.First(s => s.IsFailure).Error);

        List<SocialNetwork>? socialNetworksResult = socialNetworks.Select(s => s.Value).ToList();
        volunteer.Details.UpdateSocialNetworks(socialNetworksResult);

        var id = await _repository.Save(volunteer, cancellationToken);

        _logger.LogInformation("Social Networks for volunteer {id} updated", volunteerId);

        return id;
    }
}
