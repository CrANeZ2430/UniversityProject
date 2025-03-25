using University.Core.Common;
using University.Core.Domain.Departments.Models;
using University.Core.Domain.Groups.Data;

namespace University.Core.Domain.Groups.Models;

public class Group : Entity
{
    private readonly Department _department;

    private Group() { }

    public Group(
        Guid groupId,
        string name,
        int maxStudents,
        Guid departmentId)
    {

    }

    public Guid GroupId { get; private set; }
    public string Name { get; private set; }
    public int MaxStudents { get; private set; }
    public Guid DepartmentId { get; private set; }
    public Department Department => _department;

    public static async Task<Group> Create(CreateGroupData data)
    {


        return new Group(
            data.GroupId,
            data.Name,
            data.MaxStudents,
            data.DepartmentId);
    }
}
