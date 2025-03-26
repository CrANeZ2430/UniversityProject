using MediatR;
using University.Core.Common;
using University.Core.Domain.Groups.Common;
using University.Core.Domain.Students.Common;
using University.Core.Domain.Students.Data;
using University.Core.Domain.Students.Models;

namespace University.Application.Domain.Students.Commands.CreateStudent;

public class CreateStudentCommandHandler(
    IGroupsRepository groupsRepository,
    IStudentsRepository studentsRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateStudentCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateStudentCommand command, 
        CancellationToken cancellationToken = default)
    {
        var data = new CreateStudentData(
            command.FirstName,
            command.LastName,
            command.MiddleName,
            command.Email,
            command.PhoneNumber,
            command.GroupId);

        var student = await Student.Create(data, groupsRepository);

        await studentsRepository.Add(student, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return student.StudentId;
    }
}
