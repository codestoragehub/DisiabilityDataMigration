using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums
{
    public enum HowDidYouHearAboutUsType
    {
        None = 0,

        [Display(Name = "Commonwealth of Massachusetts")]
        CommonwealthOfMassachusetts = 1,

        [Display(Name = "Commonwealth of Pennsylvania")]
        CommonwealthOfPennsylvania = 2,

        [Display(Name = "Another Certified DOBE")]
        AnotherCertifiedDobe = 3,

        [Display(Name = "Another Diverse Supplier")]
        AnotherDiverseSupplier = 4,

        [Display(Name = "Another Certifying Organization")]
        AnotherCertifyingOrganization = 5,

        [Display(Name = "Another Disability Advocacy Organization")]
        AnotherDisabilityAdvocacyOrganization = 6,

        [Display(Name = "Vocational Rehabilitation Center")]
        AVocationalRehabilitationCenter = 7,

        [Display(Name = "Veterans' Advocacy Organization")]
        AVeteransAdvocacyOrganization = 8,

        [Display(Name = "Internet Search/Disability:IN website")]
        InternetSearchDisabilityInWebsite = 9,

        [Display(Name = "Social Media")]
        SocialMedia = 10,

        [Display(Name = "Disability:IN Annual Conference")]
        DisabilityInAnnualConference = 11,

        [Display(Name = "Disability:IN Affiliate")]
        ADisabilityInAffiliate = 12,

        [Display(Name = "Event/Conference")]
        EventConference = 13,

        [Display(Name = "Trade/Business Organization")]
        ATradeBusinessOrganization = 14,

        [Display(Name = "City/State/Federal Agency")]
        ACityStateFederalAgency = 15,

        [Display(Name = "Current/Former Corporate Client")]
        CurrentFormerCorporateClient = 16,

        [Display(Name = "Potential Corporate Client")]
        PotentialCorporateClient = 17,

        [Display(Name = "Disability:IN Team Member")]
        ADisabilityInTeamMember = 18,

        [Display(Name = "Friend or Business Colleague")]
        FriendOrBusinessColleague = 19,

        [Display(Name = "Other")]
        Other = 20
    }
}