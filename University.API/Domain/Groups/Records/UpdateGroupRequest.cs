namespace University.API.Domain.Groups.Records;

public record UpdateGroupRequest(
    string Name,
    int MaxStudents,
    Guid DepartmentId);
