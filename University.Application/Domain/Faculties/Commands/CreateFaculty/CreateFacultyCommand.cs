using MediatR;

namespace University.Application.Domain.Faculties.Commands.CreateFaculty;

public record CreateFacultyCommand(
    string Title,
    string Description)
    : IRequest<Guid>;