using University.Core.Domain.Departments.Models;

namespace University.Core.Domain.Departments.Common;

public interface IDepartmentsRepository
{
    Task Add(Department department, CancellationToken cancellationToken = default);
    void Remove(Department department);
    Task<Department> GetById(Guid departmentId, CancellationToken cancellationToken = default);
    Task<Department?> TryGetById(Guid departmentId, CancellationToken cancellationToken = default);
}
