using University.Core.Domain.Students.Models;

namespace University.Core.Domain.Students.Common;

public interface IStudentsRepository
{
    void Add(Student student);
    void Delete(Student student);
    Task<Student> GetById(Guid studentId, CancellationToken cancellationToken);
}
