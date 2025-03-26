using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Groups.Common;
using University.Core.Domain.Groups.Models;
using University.Core.Exceptions;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Groups.Common;

public class GroupsRepository(UniversityDbContext dbContext) : IGroupsRepository
{
    public async Task Add(Group group, CancellationToken cancellationToken = default)
    {
        await dbContext.Groups.AddAsync(group);
    }

    public void Remove(Group group)
    {
        dbContext.Remove(group);
    }

    public async Task<Group> GetById(Guid groupId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Groups
            .FirstOrDefaultAsync(x => x.GroupId == groupId, cancellationToken)
            ?? throw new NotFoundException($"Cannot find the {nameof(Group)} with id {groupId}");
    }

    public async Task<Group> GetByIdWithStudents(Guid groupId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Groups
            .Include(x => x.Students)
            .FirstOrDefaultAsync(x => x.GroupId == groupId, cancellationToken)
            ?? throw new NotFoundException($"Cannot find the {nameof(Group)} with id {groupId}");
    }

    public async Task<bool> Exits(Guid groupId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Groups
            .AnyAsync(x => x.GroupId == groupId, cancellationToken);
    }
}
