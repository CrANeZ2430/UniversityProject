using University.Core.Domain.Groups.Models;

namespace University.Core.Domain.Groups.Common;

public interface IGroupsRepository
{
    Task Add(Group faculty);
    void Remove(Group faculty);
    Task<Group> GetById(Guid facultyId, CancellationToken cancellationToken = default);
    Task<Group?> TryGetById(Guid facultyId, CancellationToken cancellationToken = default);
}
