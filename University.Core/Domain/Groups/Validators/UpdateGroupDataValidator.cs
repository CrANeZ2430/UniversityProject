using FluentValidation;
using University.Core.Domain.Departments.Common;
using University.Core.Domain.Departments.Models;
using University.Core.Domain.Groups.Data;

namespace University.Core.Domain.Groups.Validators;

public class UpdateGroupDataValidator : AbstractValidator<UpdateGroupData>
{
    public UpdateGroupDataValidator(
        IDepartmentsRepository departmentsRepository)
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage($"{nameof(CreateGroupData.Name)} cannot be empty")
            .MaximumLength(30).WithMessage($"{nameof(CreateGroupData.Name)} max length is 30");

        RuleFor(x => x.MaxStudents)
            .NotEmpty().WithMessage($"{nameof(CreateGroupData.MaxStudents)} cannot be empty")
            .GreaterThan(0).WithMessage($"{nameof(CreateGroupData.MaxStudents)} must be a positive integer");

        RuleFor(x => x.DepartmentId)
            .NotEmpty().WithMessage($"{nameof(CreateGroupData.DepartmentId)} cannot be empty")
            .MustAsync(async (id, cancellationToken) => await departmentsRepository.Exits(id, cancellationToken))
            .WithMessage($"{nameof(CreateGroupData.DepartmentId)} must be {nameof(Department)} id");
    }
}
