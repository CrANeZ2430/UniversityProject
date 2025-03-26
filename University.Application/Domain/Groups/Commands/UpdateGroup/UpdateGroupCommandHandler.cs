using MediatR;
using University.Core.Common;
using University.Core.Domain.Departments.Common;
using University.Core.Domain.Groups.Common;
using University.Core.Domain.Groups.Data;

namespace University.Application.Domain.Groups.Commands.UpdateGroup;

public class UpdateGroupCommandHandler(
    IDepartmentsRepository departmentsRepository,
    IGroupsRepository groupsRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateGroupCommand>
{
    public async Task Handle(UpdateGroupCommand command, CancellationToken cancellationToken)
    {
        var group = await groupsRepository.GetById(command.GroupId, cancellationToken);

        var data = new UpdateGroupData(
            command.Name,
            command.MaxStudents,
            command.DepartmentId);

        await group.Update(data, departmentsRepository, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
