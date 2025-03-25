using FluentValidation;
using University.Core.Domain.Groups.Data;

namespace University.Core.Domain.Groups.Validators;

public class CreateGroupDataValidator : AbstractValidator<CreateGroupData>
{
    public CreateGroupDataValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage($"{nameof(CreateGroupData.Name)} cannot be empty")
            .MaximumLength(30).WithMessage($"{nameof(CreateGroupData.Name)} max length is 30");
    }
}
