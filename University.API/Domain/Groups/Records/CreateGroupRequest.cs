namespace University.API.Domain.Groups.Records;

public record CreateGroupRequest(
    string Name,
    int MaxStudents,
    Guid DepartmentId);
