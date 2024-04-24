using DisabilityInPortal.Domain.Enums;
using FluentValidation;

namespace DisabilityInPortal.ApplicationLayer.Features.SiteVisitReviews.Dtos;

public class SiteVisitReviewDtoValidator : AbstractValidator<SiteVisitReviewDto>
{
    public SiteVisitReviewDtoValidator()
    {
        AddBeginSiteFormValidations();
        AddRecommendationValidations();
    }

    private void AddBeginSiteFormValidations()
    {
        RuleFor(s => s.SiteVisitDate)
            .NotEmpty().NotNull();

        RuleFor(s => s.SiteVisitorFirstName)
            .NotNull()
            .WithMessage("{PropertyName} must not be empty.");

        RuleFor(s => s.SiteVisitorLastName)
            .NotNull()
            .WithMessage("{PropertyName} must not be empty.");

        RuleFor(s => s.CompanyName)
            .NotNull()
            .WithMessage("{PropertyName} must not be empty.");

        RuleFor(s => s.CompanyAddress)
            .NotNull()
            .WithMessage("{PropertyName} must not be empty.");
    }

    private void AddRecommendationValidations()
    {
        RuleFor(s => s.Recommendation)
        .IsInEnum()
        .NotEqual(RecommendationType.None)
        .WithMessage("Recommendation Type must not be None");

        RuleFor(s => s.RecommendationReasons)
        .NotEmpty()
        .NotNull()
        .When(s => s.Recommendation == RecommendationType.Certify);

        RuleFor(s => s.OtherReviewSectionName)
        .NotEmpty()
        .NotNull()
        .When(s => s.IsOtherSectionReview);

        RuleFor(s => s.IsFormDetailsConfirmed)
        .Equal(true)
        .WithMessage("Please select to confirm all details entered on this form.");
    }
}
