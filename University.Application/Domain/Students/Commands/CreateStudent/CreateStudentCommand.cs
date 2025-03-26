using MediatR;

namespace University.Application.Domain.Students.Commands.CreateStudent;

public record CreateStudentCommand(
    string FirstName,
    string LastName,
    string? MiddleName,
    string Email,
    string PhoneNumber,
    Guid GroupId)
    : IRequest<Guid>;
