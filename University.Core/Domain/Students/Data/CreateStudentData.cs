namespace University.Core.Domain.Students.Data;

public record CreateStudentData(
    string FirstName,
    string LastName,
    string? MiddleName,
    string Email,
    string PhoneNumber,
    Guid GroupId);
