using MediatR;
using University.Core.Common;
using University.Core.Domain.Students.Common;

namespace University.Application.Domain.Students.Commands.DeleteStudent;

public class DeleteStudentCommandHandler(
    IStudentsRepository studentsRepository,
    IUnitOfWork unitOfWork) 
    : IRequestHandler<DeleteStudentCommand>
{
    public async Task Handle(
        DeleteStudentCommand request, 
        CancellationToken cancellationToken)
    {
        var student = await studentsRepository.GetById(request.StudentId, cancellationToken);

        studentsRepository.Remove(student);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
