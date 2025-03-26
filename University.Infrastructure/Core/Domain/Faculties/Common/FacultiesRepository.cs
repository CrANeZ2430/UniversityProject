using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Faculties.Common;
using University.Core.Domain.Faculties.Models;
using University.Core.Exceptions;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Faculties.Common;

public class FacultiesRepository(UniversityDbContext dbContext) : IFacultiesRepository
{
    public async Task Add(Faculty faculty, CancellationToken cancellationToken = default)
    {
        await dbContext.AddAsync(faculty);
    }

    public void Remove(Faculty faculty)
    {
        dbContext.Remove(faculty);
    }

    public async Task<Faculty> GetById(Guid facultyId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Faculties
            .FirstOrDefaultAsync(x => x.FacultyId == facultyId, cancellationToken)
            ?? throw new NotFoundException($"Cannot find the {nameof(Faculty)} with id {facultyId}");
    }

    public async Task<Faculty?> TryGetById(Guid facultyId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Faculties
            .FirstOrDefaultAsync(x => x.FacultyId == facultyId, cancellationToken);
    }
}
