using MediatR;
using University.Core.Common;
using University.Core.Domain.Departments.Common;
using University.Core.Domain.Departments.Data;
using University.Core.Domain.Faculties.Common;

namespace University.Application.Domain.Departments.Commands.UpdateDepartment;

public class UpdateDepartmentCommandHandler(
    IFacultiesRepository facultiesRepository,
    IDepartmentsRepository departmentsRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateDepartmentCommand>
{
    public async Task Handle(
        UpdateDepartmentCommand command, 
        CancellationToken cancellationToken)
    {
        var department = await departmentsRepository.GetById(command.DepartmentId, cancellationToken);

        var data = new UpdateDepartmentData(
            command.Title,
            command.Description,
            command.FacultyId);

        await department.Update(data, facultiesRepository, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
