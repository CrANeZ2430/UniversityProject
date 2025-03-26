namespace University.Core.Domain.Students.Checkers;

public interface IPhoneMustBeUniqueChecker
{
    Task<bool> IsUnique(string phoneNumber, CancellationToken cancellationToken);
}
