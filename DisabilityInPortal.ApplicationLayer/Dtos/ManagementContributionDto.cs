namespace DisabilityInPortal.ApplicationLayer.Features.ManagementContributions.Queries.GetManagementContributionById;

public class ManagementContributionDto
{
    public int ManagementContributionId { get; set; }
    public int OwnerId { get; set; }
    public bool HasMoneyContribution { get; set; }
    public decimal? Money { get; set; }
    public bool HasEquipmentContribution { get; set; }
    public string Equipment { get; set; }
    public bool HasRealEstateContribution { get; set; }
    public string RealEstate { get; set; }
    public bool HasOtherContribution { get; set; }
    public string Other { get; set; }
    public int ApplicationId { get; set; }
}