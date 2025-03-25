using MediatR;

namespace University.Application.Domain.Groups.Commands.DeleteCommand;

public record DeleteGroupCommand(
    Guid GroupId)
    : IRequest;
