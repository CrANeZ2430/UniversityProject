using MediatR;

namespace University.Application.Domain.Departments.Commands.CreateDepartment;

public record CreateDepartmentCommand(
    string Title,
    string Description,
    Guid FacultyId)
    : IRequest<Guid>;
