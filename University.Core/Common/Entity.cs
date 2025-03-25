using FluentValidation;
using FluentValidation.Results;
using University.Core.Exceptions;
using ValidationException = University.Core.Exceptions.ValidationException;

namespace University.Core.Common;

public abstract class Entity
{
    protected static void Validate<T>(
        AbstractValidator<T> validator, 
        T data)
    {
        var validationResult = validator.Validate(data);
        ThrowIfNotValid(validationResult);
    }

    protected static async Task ValidateAsync<T>(
        AbstractValidator<T> validator, 
        T data,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(data, cancellationToken);
        ThrowIfNotValid(validationResult);
    }

    protected static void CheckRule(IBusinessRule businessRule)
    {
        var ruleResult = businessRule.Check();
        if (ruleResult.IsFailed)
            throw new RuleValidationException(ruleResult.Errors);
    }

    protected static async Task CheckRuleAsync(
        IBusinessRuleAsync businessRuleAsync, 
        CancellationToken cancellationToken = default)
    {
        var ruleResult = await businessRuleAsync.CheckAsync();
        if (ruleResult.IsFailed)
            throw new RuleValidationException(ruleResult.Errors);
    }

    private static void ThrowIfNotValid(ValidationResult validationResult)
    {
        if(!validationResult.IsValid) throw new ValidationException(validationResult.Errors);
    }
}
