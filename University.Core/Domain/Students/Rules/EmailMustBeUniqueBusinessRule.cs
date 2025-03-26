using University.Core.Common;
using University.Core.Domain.Students.Checkers;
using University.Core.Domain.Students.Models;

namespace University.Core.Domain.Students.Rules;

public class EmailMustBeUniqueBusinessRule(
    string email,
    IEmailMustBeUniqueChecker checker)
    : IBusinessRuleAsync
{
    public async Task<RuleResult> CheckAsync(CancellationToken cancellationToken = default)
    {
        var isUnique = await checker.IsUnique(email, cancellationToken);
        return Check(isUnique);
    }

    private RuleResult Check(bool isBelongs)
    {
        if (isBelongs) return RuleResult.Success();
        return RuleResult.Failed($"{nameof(Student)}'s {nameof(Student.Email)} must be unique.");
    }
}
