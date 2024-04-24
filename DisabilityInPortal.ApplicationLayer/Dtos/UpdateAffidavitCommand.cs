using DisabilityInPortal.Domain.ResponseResult;
using MediatR;

namespace DisabilityInPortal.ApplicationLayer.Features.Affidavits;

public class UpdateAffidavitCommand : IRequest<BaseResponseResult<AffidavitDto>>
{
    public AffidavitDto Affidavit { get; set; }
}