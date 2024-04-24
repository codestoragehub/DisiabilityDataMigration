using FluentValidation;

namespace DisabilityInPortal.ApplicationLayer.Extensions;

public static class FluentValidationExtensions
{
    public static IRuleBuilderOptions<T, TProperty> WithGlobalMessage<T, TProperty>(
        this IRuleBuilderOptions<T, TProperty> rule,
        string errorMessage)
    {
        return rule.Configure(rule => rule.MessageBuilder = _ => errorMessage);
    }
}