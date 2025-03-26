using MediatR;
using University.Core.Common;
using University.Core.Domain.Groups.Common;
using University.Core.Domain.Students.Common;
using University.Core.Domain.Students.Data;

namespace University.Application.Domain.Students.Commands.ReassignGroup;

public class ReassignGroupCommandHandler(
    IGroupsRepository groupsRepository,
    IStudentsRepository studentsRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<ReassignGroupCommand>
{
    public async Task Handle(
        ReassignGroupCommand command, 
        CancellationToken cancellationToken)
    {
        var student = await studentsRepository.GetById(command.StudentId, cancellationToken);

        var data = new ReassignGroupData(
            command.GroupId);

        await student.ReassignGroup(
            data,
            groupsRepository,
            cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
