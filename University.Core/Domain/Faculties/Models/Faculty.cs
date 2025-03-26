using University.Core.Common;
using University.Core.Domain.Departments.Models;
using University.Core.Domain.Faculties.Data;
using University.Core.Domain.Faculties.Validators;

namespace University.Core.Domain.Faculties.Models;

public class Faculty : Entity
{
    private readonly List<Department> _departments;

    private Faculty() { }

    public Faculty(
        Guid facultyId,
        string title, 
        string description)
    {
        FacultyId = facultyId;
        Title = title;
        Description = description;
    }

    public Guid FacultyId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public IReadOnlyCollection<Department> Departments => _departments;

    public static async Task<Faculty> Create(
        CreateFacultyData data,
        CancellationToken cancellationToken = default)
    {
        await ValidateAsync(new CreateFacultyDataValidator(), data, cancellationToken);

        return new Faculty(
            Guid.NewGuid(),
            data.Title,
            data.Description);
    }

    public async Task Update(
        UpdateFacultyData data,
        CancellationToken cancellationToken = default)
    {
        await ValidateAsync(new UpdateFacultyDataValidator(), data, cancellationToken);

        Title = data.Title;
        Description = data.Description;
    }
}
