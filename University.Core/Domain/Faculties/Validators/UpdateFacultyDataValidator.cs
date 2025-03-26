using FluentValidation;
using University.Core.Domain.Faculties.Data;

namespace University.Core.Domain.Faculties.Validators;

public class UpdateFacultyDataValidator : AbstractValidator<UpdateFacultyData>
{
    public UpdateFacultyDataValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage($"{nameof(CreateFacultyData.Title)} cannot be empty")
            .MaximumLength(30).WithMessage($"{nameof(CreateFacultyData.Title)} max length is 30");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage($"{nameof(CreateFacultyData.Description)} cannot be empty")
            .MaximumLength(2000).WithMessage($"{nameof(CreateFacultyData.Description)} max length is 2000");
    }
}
