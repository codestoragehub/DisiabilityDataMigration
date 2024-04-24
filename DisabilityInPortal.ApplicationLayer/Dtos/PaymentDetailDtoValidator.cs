using FluentValidation;

namespace DisabilityInPortal.ApplicationLayer.Features.Payments.Dtos;

public class PaymentDetailDtoValidator : AbstractValidator<PaymentDetailDto>
{
    public PaymentDetailDtoValidator()
    {
        RuleFor(p => p.ApplicationReference)
            .NotNull()
            .NotEmpty();

        RuleFor(p => p.NumberOfDaysToExpedite)
            .GreaterThan(0)
            .When(p => p.IsExpeditedApplication);

        RuleFor(p => p.StripeCustomerId)
            .NotNull()
            .NotEmpty();
        
        RuleFor(p => p.StripePaymentMethod)
            .NotNull()
            .NotEmpty();

        RuleFor(p => p.Affidavit.IsAccepted)
            .Equal(true)
            .WithMessage("You need to accept affidavit first to submit your application");
    }
}