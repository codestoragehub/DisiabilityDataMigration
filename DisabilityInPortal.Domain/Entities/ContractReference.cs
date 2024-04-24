using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisabilityInPortal.Domain.Entities;

[Table("ContractReferences")]
public class ContractReference
{
    public int ContractReferenceId { get; set; }

    [StringLength(1024)]
    public string CompanyOrOrganizationName { get; set; }

    public int? AddressId { get; set; }
    public Address Address { get; set; }

    [StringLength(1024)]
    public string BuyerOrRepresentative { get; set; }

    [StringLength(1024)]
    public string ProductOrService { get; set; }

    public decimal DollarValue { get; set; }
    public int ApplicationId { get; set; }
    public Application Application { get; set; }

    public int? DocumentId { get; set; }
    public Document Document { get; set; }
}