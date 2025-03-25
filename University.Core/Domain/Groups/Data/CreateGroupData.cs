namespace University.Core.Domain.Groups.Data;

public record CreateGroupData(
    Guid GroupId,
    string Name,
    int MaxStudents,
    Guid DepartmentId);
