using University.Core.Common;
using University.Core.Domain.Groups.Common;
using University.Core.Domain.Groups.Models;
using University.Core.Domain.Students.Checkers;
using University.Core.Domain.Students.Common;
using University.Core.Domain.Students.Data;
using University.Core.Domain.Students.Validators;

namespace University.Core.Domain.Students.Models;

public class Student : Entity
{
    private readonly Group _group;

    private Student() { }

    public Student(
        Guid studentId,
        string firstName,
        string lastName,
        string? middleName,
        string email,
        string phoneNumber,
        Guid groupId)
    {
        StudentId = studentId;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Email = email;
        PhoneNumber = phoneNumber;
        GroupId = groupId;
    }

    public Guid StudentId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string? MiddleName {  get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public Guid GroupId {  get; private set; }
    public Group Group => _group;
    
    public static async Task<Student> Create(
        CreateStudentData data,
        IGroupsRepository groupsRepository,
        IEmailMustBeUniqueChecker emailChecker,
        IPhoneMustBeUniqueChecker phoneChecker,
        CancellationToken cancellationToken = default)
    {
        await ValidateAsync(
            new CreateStudentDataValidator(
                groupsRepository, 
                emailChecker, 
                phoneChecker), 
            data, 
            cancellationToken);

        return new Student(
            Guid.NewGuid(),
            data.FirstName,
            data.LastName,
            data.MiddleName,
            data.Email,
            data.PhoneNumber,
            data.GroupId);
    }

    public async Task Update(
        UpdateStudentData data,
        IGroupsRepository groupsRepository,
        IEmailMustBeUniqueChecker emailChecker,
        IPhoneMustBeUniqueChecker phoneChecker,
        CancellationToken cancellationToken = default)
    {
        await ValidateAsync(new UpdateStudentDataValidator(
            groupsRepository,
            emailChecker,
            phoneChecker), 
            data, 
            cancellationToken);

        FirstName = data.FirstName;
        LastName = data.LastName;
        MiddleName = data.MiddleName;
        Email = data.Email;
        PhoneNumber = data.PhoneNumber;
        GroupId = data.GroupId;
    }

    public async Task ReassignGroup(
        ReassignGroupData data,
        IGroupsRepository groupsRepository,
        CancellationToken cancellationToken = default)
    {
        await ValidateAsync(
            new ReassignGroupDataValidator(
                groupsRepository), 
            data, 
            cancellationToken);

        GroupId = data.GroupId;
    }
}
