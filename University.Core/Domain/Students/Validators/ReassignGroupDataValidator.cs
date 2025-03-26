using FluentValidation;
using University.Core.Domain.Groups.Common;
using University.Core.Domain.Groups.Models;
using University.Core.Domain.Students.Data;

namespace University.Core.Domain.Students.Validators;

public class ReassignGroupDataValidator : AbstractValidator<ReassignGroupData>
{
    public ReassignGroupDataValidator(IGroupsRepository groupsRepository)
    {
        RuleFor(x => x.GroupId)
            .NotEmpty().WithMessage($"{nameof(CreateStudentData.GroupId)} cannot be empty")
            .MustAsync(async (id, cancellationToken) => await groupsRepository.Exits(id, cancellationToken))
            .WithMessage($"{nameof(CreateStudentData.GroupId)} must be {nameof(Group)} id");
    }
}
