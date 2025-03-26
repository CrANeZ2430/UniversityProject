namespace University.Application.Domain.Faculties.Queries.GetFaculties;

public record GroupDto(
    Guid GroupId,
    string Name,
    int MaxStudents,
    int CurrentStudents,
    StudentDto[] Students);
