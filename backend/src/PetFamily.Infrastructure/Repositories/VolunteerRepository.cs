using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetFamily.Application.Volunteers;
using PetFamily.Domain.Models.Volunteers;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.ValueObjects;

namespace PetFamily.Infrastructure.Repositories;

public class VolunteerRepository : IVolunteerRepository
{
    private readonly ApplicationDbContext _dbContext;

    public VolunteerRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken = default)
    {
        await _dbContext.Volunteers.AddAsync(volunteer, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return volunteer.Id;
    }

    public async Task<Result<Volunteer, Error>> GetById(VolunteerId volunteerId, CancellationToken cancellationToken = default)
    {
        var volunteer = await _dbContext.Volunteers
            .Include(x => x.Pets)
             .ThenInclude(p => p.PetPhotoList)
            .FirstOrDefaultAsync(v => v.Id == volunteerId, cancellationToken);

        if (volunteer is null)
            return Errors.General.NotFound(volunteerId);

        return volunteer;
    }

    public async Task<Result<Volunteer, Error>> GetByPhone(PhoneNumber requestPhone, CancellationToken cancellationToken = default)
    {
        var volunteer = await _dbContext.Volunteers
            .Include(v => v.Pets)
            .FirstOrDefaultAsync(p => p.PhoneNumber == requestPhone, cancellationToken);

        if (volunteer is null)
        {
            return Errors.General.NotFound(Guid.Empty);
        }

        return volunteer;
    }

    public async Task<Guid> Save(Volunteer volunteer, CancellationToken cancellationToken = default)
    {
        _dbContext.Attach(volunteer);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return volunteer.Id.Value;
    }
}