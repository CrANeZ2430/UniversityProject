using University.Core.Domain.Students.Models;

namespace University.Core.Domain.Students.Common;

public interface IStudentsRepository
{
    Task Add(Student student, CancellationToken cancellationToken = default);
    void Remove(Student student);
    Task<Student> GetById(Guid studentId, CancellationToken cancellationToken = default);
    Task<Student?> TryGetById(Guid studentId, CancellationToken cancellationToken = default);
}
