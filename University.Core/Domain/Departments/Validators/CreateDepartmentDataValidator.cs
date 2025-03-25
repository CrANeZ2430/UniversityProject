using FluentValidation;
using FluentValidation.Results;
using University.Core.Domain.Departments.Data;
using University.Core.Domain.Faculties.Common;
using University.Core.Domain.Faculties.Models;

namespace University.Core.Domain.Departments.Validators;

public class CreateDepartmentDataValidator : AbstractValidator<CreateDepartmentData>
{
    public CreateDepartmentDataValidator(
        IFacultiesRepository facultiesRepository)
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage($"{nameof(CreateDepartmentData.Title)} cannot be empty")
            .MaximumLength(30).WithMessage($"{nameof(CreateDepartmentData.Title)} max length is 30");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage($"{nameof(CreateDepartmentData.Description)} cannot be empty")
            .MaximumLength(2000).WithMessage($"{nameof(CreateDepartmentData.Description)} max length is 2000");

        RuleFor(x => x.FacultyId)
            .NotEmpty().WithMessage($"{nameof(CreateDepartmentData.FacultyId)} cannot be empty")
            .MustAsync(async (id , cancellationToken) => await facultiesRepository.TryGetById(id, cancellationToken) != null)
            .WithMessage($"{nameof(CreateDepartmentData.FacultyId)} must be {nameof(Faculty)} id");
    }
}
