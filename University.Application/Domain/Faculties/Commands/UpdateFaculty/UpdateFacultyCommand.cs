using MediatR;

namespace University.Application.Domain.Faculties.Commands.UpdateFaculty;

public record UpdateFacultyCommand(
    Guid FacultyId,
    string Title,
    string Description)
    : IRequest;
