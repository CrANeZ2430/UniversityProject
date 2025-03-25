namespace University.Core.Exceptions;

public class RuleValidationException(IEnumerable<string> failures) : DomainException("Validation is failed")
{
    public IReadOnlyCollection<string> Failures { get; } = failures.ToList().AsReadOnly();
}
