using MediatR;
using University.Core.Common;
using University.Core.Domain.Departments.Common;
using University.Core.Domain.Groups.Common;
using University.Core.Domain.Groups.Data;
using University.Core.Domain.Groups.Models;

namespace University.Application.Domain.Groups.Commands.CreateGroup;

public class CreateGroupCommandHandler(
    IGroupsRepository groupsRepository,
    IDepartmentsRepository departmentsRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateGroupCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateGroupCommand command, 
        CancellationToken cancellationToken = default)
    {
        var data = new CreateGroupData(
            command.Name,
            command.MaxStudents,
            command.DepartmentId);

        var group = await Group.Create(data, departmentsRepository);

        await groupsRepository.Add(group);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return group.GroupId;
    }
}
