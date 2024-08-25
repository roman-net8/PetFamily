using Microsoft.EntityFrameworkCore;
using PetFamily.Domain.Models.Volunteers;

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

    public async Task<Volunteer> GetById(VolunteerId volunteerId)
    {
        Volunteer? volunteer = await _dbContext.Volunteers 
            .Include(x => x.OwnedPets) 
            .FirstOrDefaultAsync(v => v.Id == volunteerId);

        if (volunteer == null)
        {
            throw new NullReferenceException(nameof(volunteer));
        }

        return volunteer;
    }
}
