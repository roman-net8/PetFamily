using PetFamily.Domain.Models.Volunteers;

namespace PetFamily.Application.Volunteers;

public interface IVolunteersRepositories
{
    Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken);
}
