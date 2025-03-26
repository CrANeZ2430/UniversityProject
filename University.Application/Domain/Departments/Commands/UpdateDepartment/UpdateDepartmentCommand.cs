using MediatR;

namespace University.Application.Domain.Departments.Commands.UpdateDepartment;

public record UpdateDepartmentCommand(
    Guid DepartmentId,
    string Title,
    string Description,
    Guid FacultyId)
    : IRequest;
