using DisabilityInPortal.ApplicationLayer.Features.Addresses.Queries.GetAddressById;

namespace DisabilityInPortal.ApplicationLayer.Features.ContractReferences.Queries.GetContractReferencesById;

public class ContractReferenceDto : AddressDto
{
    public int ContractReferenceId { get; set; }
    public string CompanyOrOrganizationName { get; set; }
    public string BuyerOrRepresentative { get; set; }
    public string ProductOrService { get; set; }
    public decimal DollarValue { get; set; }
    public new int ApplicationId { get; set; }
    public int? DocumentId { get; set; }
}