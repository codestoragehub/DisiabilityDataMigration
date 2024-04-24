using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisabilityInPortal.Domain.Entities;

[Table("TransportationDetails")]
public class TransportationDetail
{
    public int TransportationDetailId { get; set; }

    public bool DoesCompanyInvolveTransportation { get; set; }

    [StringLength(1024)]
    public string OperatingStatus { get; set; }

    [StringLength(1024)]
    public string CommonCarrier { get; set; }

    [StringLength(1024)]
    public string IndependentCarrier { get; set; }

    [StringLength(1024)]
    public string InsuranceCarrier { get; set; }

    [StringLength(1024)]
    public string Commodities { get; set; }

    public bool IsFleetContracted { get; set; }
    public bool IsFleetLeased { get; set; }
    public bool IsFleetOwned { get; set; }

    public int? ContractDocumentId { get; set; }
    public Document ContractDocument { get; set; }

    public int? LeaseDocumentId { get; set; }
    public Document LeaseDocument { get; set; }

    public int ApplicationId { get; set; }
    public Application Application { get; set; }
}