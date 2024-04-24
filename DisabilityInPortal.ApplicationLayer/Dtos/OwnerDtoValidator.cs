using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;
using DisabilityInPortal.Domain.Enums;
using FluentValidation;

namespace DisabilityInPortal.ApplicationLayer.Features.Owners.Dtos;

public class OwnerDtoValidator : AbstractValidator<OwnerDto>
{
    public OwnerDtoValidator(IApplicationService applicationService)
    {
        RuleFor(o => o.Name)
            .NotNull()
            .NotEmpty();

        RuleFor(o => o.Title)
            .NotNull()
            .NotEmpty();

        RuleFor(o => o.Gender)
            .IsInEnum()
            .NotEqual(GenderType.None)
            .WithMessage("'Gender' must not be None");

        RuleFor(o => o.GenderOther)
            .NotEmpty()
            .When(o => o.Gender == GenderType.Other);

        WhenAsync(async (dto, _) => await applicationService.IsUsaBasedCompanyAsync(dto.ApplicationId), () =>
        {
            RuleFor(o => o.Ethinicity)
                .IsInEnum()
                .NotEqual(EthnicityType.None)
                .WithMessage("'Ethinicity' must not be None");

            RuleFor(o => o.EthinicityOther)
                .NotNull()
                .NotEmpty()
                .When(o => o.Ethinicity == EthnicityType.Other);
        }).Otherwise(() =>
        {
            RuleFor(o => o.CountryId)
                .GreaterThan(0)
                .WithMessage("Please provide a country");
        });

        RuleFor(o => o.DocumentId)
            .NotNull()
            .NotEmpty()
            .WithName("Resume");
    }
}