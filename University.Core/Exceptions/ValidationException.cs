using FluentValidation.Results;

namespace University.Core.Exceptions;

public class ValidationException : DomainException
{
    public ValidationException(List<ValidationFailure> failures) : base("Validation is failed")
    {
        Failures = failures.AsReadOnly();
    }

    public ValidationException(ValidationFailure failure) : base("Validation is failed")
    {
        Failures = [ failure ];
    }

    public IReadOnlyCollection<ValidationFailure> Failures { get; }
}
