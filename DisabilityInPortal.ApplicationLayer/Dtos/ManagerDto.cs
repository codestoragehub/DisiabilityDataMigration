using DisabilityInPortal.ApplicationLayer.Features.Owners.Dtos;
using DisabilityInPortal.ApplicationLayer.Features.SiteVisitReviews.Dtos;

namespace DisabilityInPortal.ApplicationLayer.Features.Managers.Dtos
{
    public class ManagerDto
    {
        public int ManagerId { get; set; }
        public int OwnerId { get; set; }
        public OwnerDto Owner { get; set; }
        public string OwnerDuties { get; set; }
        public int OperationAndControlId { get; set; }
        public OperationAndControlDto OperationAndControl { get; set; }
    }
}
