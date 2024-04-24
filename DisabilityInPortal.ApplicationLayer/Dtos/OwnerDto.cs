using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.ApplicationLayer.Features.Owners.Dtos;

public class OwnerDto
{
    public int OwnerId { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public GenderType Gender { get; set; }
    public string GenderOther { get; set; }
    public decimal Ownership { get; set; }
    public bool DisabilityStatus { get; set; }
    public bool ParticipatesShareVoting { get; set; }
    public bool DailyManagement { get; set; }
    public bool USCitizen { get; set; }
    public EthnicityType Ethinicity { get; set; }
    public string EthinicityOther { get; set; }
    public bool IsLGBT { get; set; }
    public int? DocumentId { get; set; }
    public int ApplicationId { get; set; }
    public int? CountryId { get; set; }
}