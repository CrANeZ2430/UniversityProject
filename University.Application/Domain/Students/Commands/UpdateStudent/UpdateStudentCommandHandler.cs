using MediatR;
using University.Core.Common;
using University.Core.Domain.Groups.Common;
using University.Core.Domain.Students.Checkers;
using University.Core.Domain.Students.Common;
using University.Core.Domain.Students.Data;

namespace University.Application.Domain.Students.Commands.UpdateStudent;

public class UpdateStudentCommandHandler(
    IGroupsRepository groupsRepository,
    IStudentsRepository studentsRepository,
    IUnitOfWork unitOfWork,
    IEmailMustBeUniqueChecker emailChecker,
    IPhoneMustBeUniqueChecker phoneChecker)
    : IRequestHandler<UpdateStudentCommand>
{
    public async Task Handle(
        UpdateStudentCommand command, 
        CancellationToken cancellationToken)
    {
        var student = await studentsRepository.GetById(command.StudentId);

        var data = new UpdateStudentData(
            command.FirstName,
            command.LastName,
            command.MiddleName,
            command.Email,
            command.PhoneNumber,
            command.GroupId);

        await student.Update(data, groupsRepository, emailChecker, phoneChecker, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
