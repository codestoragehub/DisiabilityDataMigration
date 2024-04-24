namespace DisabilityInPortal.ApplicationLayer.Features.SiteVisitReviews.Dtos;

public class ContributionOfCapitalAndExpertiseDto
{
    public string SourceOfExpertise { get; set; }
    public string YourContributionOfMoney { get; set; }
    public string YourContributionOfEquipment { get; set; }
    public string YourContributionOfRealEstate { get; set; }
    public string YourContributionOfExperience { get; set; }
    public string YourContributionOfOther { get; set; }
    public bool HasOtherIndividualsMadeContribution { get; set; }
    public string OtherContributionOfMoney { get; set; }
    public string OtherContributionOfEquipment { get; set; }
    public string OtherContributionOfRealEstate { get; set; }
    public string OtherContributionOfExperience { get; set; }
    public string OtherContributionOfOther { get; set; }
    public bool HasAnyCurrentLoans { get; set; }
    public string CircumstanceOfLoanTermsForRepayment { get; set; }
    public string SiteVisitorsComment { get; set; }
}