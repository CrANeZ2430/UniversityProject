namespace University.Core.Domain.Departments.Data;

public record CreateDepartmentData(
    string Title,
    string Description,
    Guid FacultyId);
