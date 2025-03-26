using MediatR;
using University.Core.Common;
using University.Core.Domain.Departments.Common;
using University.Core.Domain.Departments.Data;
using University.Core.Domain.Departments.Models;
using University.Core.Domain.Faculties.Common;

namespace University.Application.Domain.Departments.Commands.CreateDepartment;

public class CreateDepartmentCommandHandler(
    IDepartmentsRepository departmentsRepository,
    IFacultiesRepository facultiesRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateDepartmentCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateDepartmentCommand command, 
        CancellationToken cancellationToken = default)
    {
        var data = new CreateDepartmentData(
            command.Title,
            command.Description,
            command.FacultyId);

        var department = await Department.Create(data, facultiesRepository);

        await departmentsRepository.Add(department, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return department.DepartmentId;
    }
}
