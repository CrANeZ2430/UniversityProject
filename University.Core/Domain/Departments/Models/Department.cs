using University.Core.Common;
using University.Core.Domain.Departments.Data;
using University.Core.Domain.Departments.Validators;
using University.Core.Domain.Faculties.Common;
using University.Core.Domain.Faculties.Models;
using University.Core.Domain.Groups.Models;

namespace University.Core.Domain.Departments.Models;

public class Department : Entity
{
    private readonly Faculty _faculty;
    private readonly List<Group> _groups;

    private Department() { }

    public Department(
        Guid departmentId,
        string title,
        string description,
        Guid facultyId)
    {
        DepartmentId = departmentId;
        Title = title;
        Description = description;
        FacultyId = facultyId;
    }

    public Guid DepartmentId { get; private set; }
    public string Title { get; private set; }
    public string Description {  get; private set; }
    public Guid FacultyId { get; private set; }
    public Faculty Faculty => _faculty;
    public IReadOnlyCollection<Group> Groups => _groups;

    public static async Task<Department> Create(
        CreateDepartmentData data, 
        IFacultiesRepository facultiesRepository, 
        CancellationToken cancellationToken = default)
    {
        await ValidateAsync(new CreateDepartmentDataValidator(facultiesRepository), data, cancellationToken);

        return new Department(
            Guid.NewGuid(),
            data.Title,
            data.Description,
            data.FacultyId);
    }
}
