using MediatR;

namespace University.Application.Domain.Students.Commands.UpdateStudent;

public record UpdateStudentCommand(
    Guid StudentId,
    string FirstName,
    string LastName,
    string? MiddleName,
    string Email,
    string PhoneNumber,
    Guid GroupId)
    : IRequest;
