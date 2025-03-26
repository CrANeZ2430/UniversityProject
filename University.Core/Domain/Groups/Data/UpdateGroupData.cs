namespace University.Core.Domain.Groups.Data;

public record UpdateGroupData(
    string Name,
    int MaxStudents,
    Guid DepartmentId);
