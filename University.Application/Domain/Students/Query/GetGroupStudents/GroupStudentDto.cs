namespace University.Application.Domain.Students.Query.GetGroupStudents;

public record GroupStudentDto(
    Guid StudentId,
    string FirstName,
    string LastName,
    string? MiddleName,
    string Email,
    string PhoneNumber);
