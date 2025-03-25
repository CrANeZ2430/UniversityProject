namespace University.Core.Domain.Students.Models;

public class Student
{
    private Student() { }
    public Guid StudentId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
}
