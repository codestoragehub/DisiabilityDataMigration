using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisabilityInPortal.Domain.Entities;

[Table("ManagementChanges")]
public class ManagementChange
{
    public ManagementChange()
    {
        ManagementChangeAgreements = new List<ManagementChangeAgreement>();
    }
    
    public int ManagementChangeId { get; set; }

    public bool HasOrIntendToEnterIntoAnyTypeOfAgreement { get; set; }
    public List<ManagementChangeAgreement> ManagementChangeAgreements { get; set; }

    public int ApplicationId { get; set; }
    public Application Application { get; set; }
}