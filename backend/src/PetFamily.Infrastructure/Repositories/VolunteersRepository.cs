using Microsoft.EntityFrameworkCore;
using PetFamily.Domain.Models.Volunteers;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastructure.Repositories;

public class VolunteersRepository
{
    private readonly ApplicationDbContext _dbContext;

    public VolunteersRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken = default)
    {
        await _dbContext.Volunteers.AddAsync(volunteer, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return volunteer.Id;
    }
    //TODO add Result Task<Result<Module, Error>>
    public async Task<Result<Volunteer>> GetById(VolunteerId volunteerId, CancellationToken cancellationToken = default)
    {
        var volunteer = await _dbContext.Volunteers
            .Include(x => x.OwnedPets)  
            .FirstOrDefaultAsync(v => v.Id == volunteerId, cancellationToken);

        if (volunteer == null)
        {
            return Result<Volunteer>.Failure(Errors.General.NotFound(volunteerId.Value));
        }

        return Result<Volunteer>.Success(volunteer);
    }

}
