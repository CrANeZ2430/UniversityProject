using University.Core.Domain.Faculties.Models;

namespace University.Core.Domain.Faculties.Common;

public interface IFacultiesRepository
{
    Task Add(Faculty faculty, CancellationToken cancellationToken = default);
    void Remove(Faculty faculty);
    Task<Faculty> GetById(Guid facultyId, CancellationToken cancellationToken = default);
    Task<bool> Exits(Guid facultyId, CancellationToken cancellationToken = default);
}
