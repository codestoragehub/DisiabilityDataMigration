using FluentValidation;

namespace DisabilityInPortal.ApplicationLayer.Features.Managers.Dtos;

public class ManagerDtoValidator : AbstractValidator<ManagerDto>
{
    public ManagerDtoValidator()
    {
        RuleFor(m => m.OperationAndControlId)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be present.");

        RuleFor(m => m.OwnerId)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be present.");

        RuleFor(m => m.OwnerDuties)
            .NotEmpty()
            .NotNull()
            .WithName("Duties");
    }
}
