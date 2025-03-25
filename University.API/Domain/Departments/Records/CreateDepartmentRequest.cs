namespace University.API.Domain.Departments.Records;

public record CreateDepartmentRequest(
    string Title,
    string Description,
    Guid FacultyId);
