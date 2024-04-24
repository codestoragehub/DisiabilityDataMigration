using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisabilityInPortal.Domain.Entities;

[Table("ManagementAtOutsideFirms")]
public class ManagementAtOutsideFirm
{
    public ManagementAtOutsideFirm()
    {
        OutsideFirmIndividuals = new List<OutsideFirmIndividual>();
    }
    
    public int ManagementAtOutsideFirmId { get; set; }
    public bool? HasAnyManagementOutsideAtFirm { get; set; }
    public List<OutsideFirmIndividual> OutsideFirmIndividuals { get; set; }

    public int ApplicationId { get; set; }
    public Application Application { get; set; }
}