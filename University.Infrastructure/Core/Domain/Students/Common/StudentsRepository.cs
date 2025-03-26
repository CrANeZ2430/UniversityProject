using Microsoft.EntityFrameworkCore;
using University.Core.Domain.Students.Common;
using University.Core.Domain.Students.Models;
using University.Core.Exceptions;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Students.Common;

public class StudentsRepository(
    UniversityDbContext dbContext) : IStudentsRepository
{
    public async Task Add(Student student, CancellationToken cancellationToken = default)
    {
        await dbContext.AddAsync(student);
    }

    public void Remove(Student student)
    {
        dbContext.Remove(student);
    }

    public async Task<Student> GetById(Guid studentId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Students
            .FirstOrDefaultAsync(x => x.StudentId == studentId, cancellationToken)
            ?? throw new NotFoundException($"Cannot find the {nameof(Student)} with id {studentId}");
    }

    public async Task<bool> Exits(Guid studentId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Students
            .AnyAsync(x => x.StudentId == studentId, cancellationToken);
    }
}
