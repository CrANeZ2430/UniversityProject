using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Departments.Common;
using University.Core.Domain.Departments.Models;
using University.Core.Exceptions;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Departments.Common;

public class DepartmentsRepository(UniversityDbContext dbContext) : IDepartmentsRepository
{
    public async Task Add(Department department, CancellationToken cancellationToken = default)
    {
        await dbContext.AddAsync(department);
    }

    public void Remove(Department department)
    {
        dbContext.Remove(department);
    }

    public async Task<Department> GetById(Guid departmentId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Departments
            .FirstOrDefaultAsync(x => x.DepartmentId == departmentId, cancellationToken)
            ?? throw new NotFoundException($"Cannot find the {nameof(Department)} with id {departmentId}");
    }

    public async Task<bool> Exits(Guid departmentId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Departments
            .AnyAsync(x => x.DepartmentId == departmentId);
    }
}
