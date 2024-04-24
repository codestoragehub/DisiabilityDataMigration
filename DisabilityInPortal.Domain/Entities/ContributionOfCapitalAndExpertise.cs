using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisabilityInPortal.Domain.Entities;

[Table("ContributionOfCapitalAndExpertises")]
public class ContributionOfCapitalAndExpertise
{
    public int ContributionOfCapitalAndExpertiseId { get; set; }

    [StringLength(1024)]
    public string SourceOfExpertise { get; set; }

    [StringLength(1024)]
    public string YourContributionOfMoney { get; set; }

    [StringLength(1024)]
    public string YourContributionOfEquipment { get; set; }

    [StringLength(1024)]
    public string YourContributionOfRealEstate { get; set; }

    [StringLength(1024)]
    public string YourContributionOfExperience { get; set; }

    [StringLength(1024)]
    public string YourContributionOfOther { get; set; }

    public bool HasOtherIndividualsMadeContribution { get; set; }

    [StringLength(1024)]
    public string OtherContributionOfMoney { get; set; }

    [StringLength(1024)]
    public string OtherContributionOfEquipment { get; set; }

    [StringLength(1024)]
    public string OtherContributionOfRealEstate { get; set; }

    [StringLength(1024)]
    public string OtherContributionOfExperience { get; set; }

    [StringLength(1024)]
    public string OtherContributionOfOther { get; set; }

    public bool HasAnyCurrentLoans { get; set; }

    [StringLength(1024)]
    public string CircumstanceOfLoanTermsForRepayment { get; set; }

    [StringLength(1024)]
    public string SiteVisitorsComment { get; set; }

    public int SiteVisitReviewId { get; set; }
    public SiteVisitReview SiteVisitReview { get; set; }
}