namespace University.API.Domain.Students.Records;

public record UpdateStudentRequest(
    string FirstName,
    string LastName,
    string? MiddleName,
    string Email,
    string PhoneNumber,
    Guid GroupId);
