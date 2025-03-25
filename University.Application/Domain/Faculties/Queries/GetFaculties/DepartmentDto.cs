namespace University.Application.Domain.Faculties.Queries.GetFaculties;

public record DepartmentDto(
    Guid DepartmentId,
    string Title,
    string Description,
    GroupDto[] Groups);