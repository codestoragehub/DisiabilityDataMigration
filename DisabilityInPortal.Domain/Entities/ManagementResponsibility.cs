using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisabilityInPortal.Domain.Entities;

[Table("ManagementResponsibilities")]
public class ManagementResponsibility
{
    public ManagementResponsibility()
    {
        ManagementResponsibilityOwners = new List<ManagementResponsibilityOwner>();
    }

    public int ManagementResponsibilityId { get; set; }

    public List<ManagementResponsibilityOwner> ManagementResponsibilityOwners { get; set; }

    public int? OwnerId { get; set; }
    public Owner Owner { get; set; }

    public int ApplicationId { get; set; }
    public Application Application { get; set; }
}