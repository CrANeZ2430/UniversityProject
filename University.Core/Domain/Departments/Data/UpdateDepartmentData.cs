namespace University.Core.Domain.Departments.Data;

public record UpdateDepartmentData(
    string Title,
    string Description,
    Guid FacultyId);
