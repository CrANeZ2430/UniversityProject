using University.Core.Domain.Groups.Models;

namespace University.Core.Domain.Groups.Common;

public interface IGroupsRepository
{
    Task Add(Group group, CancellationToken cancellationToken = default);
    void Remove(Group group);
    Task<Group> GetById(Guid groupId, CancellationToken cancellationToken = default);
    Task<bool> Exits(Guid groupId, CancellationToken cancellationToken = default);
    Task<Group> GetByIdWithStudents(Guid groupId, CancellationToken cancellationToken = default);
}
