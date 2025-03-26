using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;
using University.Core.Domain.Groups.Common;
using University.Core.Domain.Students.Checkers;
using University.Core.Domain.Students.Data;
using University.Core.Domain.Students.Rules;

namespace University.Core.Domain.Students.Validators;

public class UpdateStudentDataValidator : AbstractValidator<UpdateStudentData>
{
    public UpdateStudentDataValidator(
        IGroupsRepository groupsRepository,
        IEmailMustBeUniqueChecker emailChecker,
        IPhoneMustBeUniqueChecker phoneChecker)
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
            .MaximumLength(40).WithMessage($"{nameof(CreateStudentData.Email)} max length is 60")
            .EmailAddress().WithMessage($"{nameof(CreateStudentData.Email)} is not valid.");
        RuleFor(x => x.Email)
        .CustomAsync(async (email, context, cancellationToken) =>
        {
            var checkResult = await new EmailMustBeUniqueBusinessRule(email, emailChecker).CheckAsync(cancellationToken);

            if (checkResult.IsSuccess) return;

            foreach (var error in checkResult.Errors)
            {
                context.AddFailure(new ValidationFailure(nameof(CreateStudentData.Email), error));
            }
        });

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage($"{nameof(CreateStudentData.PhoneNumber)} cannot be empty")
            .MaximumLength(20).WithMessage($"{nameof(CreateStudentData.MiddleName)} max length is 30")
            .Matches(new Regex(@"(\+\d{1,3} )?((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"))
            .WithMessage($"{nameof(CreateStudentData.PhoneNumber)} is not valid");
        RuleFor(p => p.PhoneNumber)
            .CustomAsync(async (phoneNumber, context, cancellationToken) =>
            {
                var checkResult = await new PhoneMustBeUniqueBusinessRule(phoneNumber, phoneChecker).CheckAsync(cancellationToken);

                if (checkResult.IsSuccess) return;

                foreach (var error in checkResult.Errors)
                {
                    context.AddFailure(new ValidationFailure(nameof(CreateStudentData.Email), error));
                }
            });

        RuleFor(x => x.GroupId)
            .NotEmpty().WithMessage($"{nameof(CreateStudentData.GroupId)} cannot be empty")
            .MustAsync(async (id, cancellationToken) => await groupsRepository.Exits(id, cancellationToken))
            .WithMessage($"{nameof(CreateStudentData.GroupId)} must be {nameof(Group)} id")
            .CustomAsync(async (id, context, cancellationToken) =>
            {
                var group = await groupsRepository.GetByIdWithStudents(id);

                var studentsCount = group.Students.Count();

                if (studentsCount != group.MaxStudents) return;

                context.AddFailure(nameof(group.GroupId), $"{nameof(Group)} has max students");
            });
    }
}
