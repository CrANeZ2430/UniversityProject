namespace University.Core.Domain.Students.Checkers;

public interface IEmailMustBeUniqueChecker
{
    Task<bool> IsUnique(string email, CancellationToken cancellationToken = default);
}
