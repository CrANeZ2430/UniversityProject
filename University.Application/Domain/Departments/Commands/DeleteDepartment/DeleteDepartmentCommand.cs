using MediatR;

namespace University.Application.Domain.Departments.Commands.DeleteDepartment;

public record DeleteDepartmentCommand(
    Guid DepartmentId)
    : IRequest;
