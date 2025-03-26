using MediatR;

namespace University.Application.Domain.Students.Commands.ReassignGroup;

public record ReassignGroupCommand(
    Guid StudentId,
    Guid GroupId)
    : IRequest;
