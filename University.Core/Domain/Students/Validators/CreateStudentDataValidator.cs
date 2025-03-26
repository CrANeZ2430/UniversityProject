using FluentValidation;
using University.Core.Domain.Groups.Common;
using University.Core.Domain.Groups.Models;
using University.Core.Domain.Students.Data;

namespace University.Core.Domain.Students.Validators;

public class CreateStudentDataValidator : AbstractValidator<CreateStudentData>
{
    public CreateStudentDataValidator(
        IGroupsRepository groupsRepository)
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage($"{nameof(CreateStudentData.FirstName)} cannot be empty")
            .MaximumLength(30).WithMessage($"{nameof(CreateStudentData.FirstName)} max length is 30");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage($"{nameof(CreateStudentData.LastName)} cannot be empty")
            .MaximumLength(30).WithMessage($"{nameof(CreateStudentData.LastName)} max length is 30");

        RuleFor(x => x.MiddleName)
            .MaximumLength(30).WithMessage($"{nameof(CreateStudentData.MiddleName)} max length is 30");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage($"{nameof(CreateStudentData.Email)} cannot be empty")
            .MaximumLength(40).WithMessage($"{nameof(CreateStudentData.Email)} max length is 60");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage($"{nameof(CreateStudentData.PhoneNumber)} cannot be empty")
            .MaximumLength(20).WithMessage($"{nameof(CreateStudentData.MiddleName)} max length is 30");

        RuleFor(x => x.GroupId)
            .NotEmpty().WithMessage($"{nameof(CreateStudentData.GroupId)} cannot be empty")
            .MustAsync(async (id, cancellationToken) => await groupsRepository.TryGetById(id) != null)
            .WithMessage($"{nameof(CreateStudentData.GroupId)} must be {nameof(Group)} id"); ;
    }
}
