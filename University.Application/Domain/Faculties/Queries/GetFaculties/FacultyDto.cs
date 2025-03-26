namespace University.Application.Domain.Faculties.Queries.GetFaculties;

public record FacultyDto(
    Guid FacultyId,
    string Title,
    string Description,
    DepartmentDto[] Departments);
