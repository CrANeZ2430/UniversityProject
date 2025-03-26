using University.Core.Common;
using University.Core.Domain.Departments.Common;
using University.Core.Domain.Departments.Models;
using University.Core.Domain.Groups.Data;
using University.Core.Domain.Groups.Validators;
using University.Core.Domain.Students.Models;

namespace University.Core.Domain.Groups.Models;

public class Group : Entity
{
    private readonly Department _department;
    public readonly List<Student> _students;

    private Group() { }

    public Group(
        Guid groupId,
        string name,
        int maxStudents,
        Guid departmentId)
    {
        GroupId = groupId;
        Name = name;
        MaxStudents = maxStudents;
        DepartmentId = departmentId;
    }

    public Guid GroupId { get; private set; }
    public string Name { get; private set; }
    public int MaxStudents { get; private set; }
    public Guid DepartmentId { get; private set; }
    public Department Department => _department;
    public IReadOnlyCollection<Student> Students => _students;

    public static async Task<Group> Create(
        CreateGroupData data,
        IDepartmentsRepository departmentsRepository,
        CancellationToken cancellationToken = default)
    {
        await ValidateAsync(new CreateGroupDataValidator(departmentsRepository), data, cancellationToken);

        return new Group(
            Guid.NewGuid(),
            data.Name,
            data.MaxStudents,
            data.DepartmentId);
    }

    public async Task Update(
        UpdateGroupData data,
        IDepartmentsRepository departmentsRepository,
        CancellationToken cancellationToken = default)
    {
        await ValidateAsync(new UpdateGroupDataValidator(departmentsRepository), data, cancellationToken);

        Name = data.Name;
        MaxStudents = data.MaxStudents;
        DepartmentId = data.DepartmentId;
    }
}
