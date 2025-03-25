using MediatR;
using University.Core.Common;
using University.Core.Domain.Departments.Common;

namespace University.Application.Domain.Departments.Commands.DeleteDepartment;

public class DeleteDepartmentCommandHandler(
    IDepartmentsRepository departmentsRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteDepartmentCommand>
{
    public async Task Handle(
        DeleteDepartmentCommand command, 
        CancellationToken cancellationToken = default)
    {
        var id = command.DepartmentId;

        var department = await departmentsRepository.GetById(id, cancellationToken);

        departmentsRepository.Remove(department);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
