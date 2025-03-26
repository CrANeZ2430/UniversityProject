using MediatR;

namespace University.Application.Domain.Groups.Commands.UpdateGroup;

public record UpdateGroupCommand(
    Guid GroupId,
    string Name,
    int MaxStudents,
    Guid DepartmentId)
    : IRequest;
