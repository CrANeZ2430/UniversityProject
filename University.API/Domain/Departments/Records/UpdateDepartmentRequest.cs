namespace University.API.Domain.Departments.Records;

public record UpdateDepartmentRequest(
    string Title,
    string Description,
    Guid FacultyId);
