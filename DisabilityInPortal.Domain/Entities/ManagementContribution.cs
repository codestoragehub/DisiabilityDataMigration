using System.ComponentModel.DataAnnotations;
using DisabilityInPortal.Domain.Entities.Common;

namespace DisabilityInPortal.Domain.Entities;

public class ManagementContribution : AuditBaseEntity
{
    public int ManagementContributionId { get; set; }

    public int OwnerId { get; set; }
    public Owner Owner { get; set; }

    public decimal? Money { get; set; }

    [StringLength(1024)]
    public string Equipment { get; set; }

    [StringLength(1024)]
    public string RealEstate { get; set; }

    [StringLength(1024)]
    public string Other { get; set; }

    public int ApplicationId { get; set; }
    public Application Application { get; set; }
}