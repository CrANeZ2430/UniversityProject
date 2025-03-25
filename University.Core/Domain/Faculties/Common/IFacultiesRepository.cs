using University.Core.Domain.Faculties.Models;

namespace University.Core.Domain.Faculties.Common;

public interface IFacultiesRepository
{
    Task Add(Faculty faculty);
    void Remove(Faculty faculty);
    Task<Faculty> GetById(Guid facultyId, CancellationToken cancellationToken = default);
    Task<Faculty?> TryGetById(Guid facultyId, CancellationToken cancellationToken = default);
}
