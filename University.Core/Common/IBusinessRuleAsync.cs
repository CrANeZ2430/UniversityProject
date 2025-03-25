namespace University.Core.Common;

public interface IBusinessRuleAsync
{
    Task<RuleResult> CheckAsync(CancellationToken cancellationToken = default);
}
