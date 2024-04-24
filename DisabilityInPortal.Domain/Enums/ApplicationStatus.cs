using System.ComponentModel;

namespace DisabilityInPortal.Domain.Enums;

public enum ApplicationStatus
{
    [Description("N/A")]
    None = 0,

    [Description("Draft")]
    Draft = 1,

    [Description("Application submitted")]
    ApplicationSubmitted = 2,

    [Description("Admin review in progress")]
    ReviewByAdminInProgress = 3,

    [Description("Admin approved")]
    AdminApproved = 4,

    [Description("Admin sent back to applicant")]
    AdminSentBackToApplicant = 5,

    [Description("Ncc review in progress")]
    ReviewByNccInProgress = 6,

    [Description("Ncc approved")]
    NccApproved = 7,

    [Description("Ncc sent back to admin")]
    NccSentBackToAdmin = 8,

    [Description("SiteVisitor review in progress")]
    ReviewBySiteVisitorInProgress = 9,

    [Description("SiteVisitor approved")]
    SiteVisitorApproved = 10,

    [Description("SiteVisitor declined")]
    SiteVisitorDeclined = 11,

    [Description("SiteVisitor further review required")]
    SiteVisitorFurtherReviewRequired = 12,

    [Description("Final decision in progress")]
    FinalDecisionInProgress = 13,

    [Description("Certified")]
    Certified = 14,

    [Description("Final decision declined")]
    FinalDecisionDeclined = 15,

    [Description("Final decision further information required")]
    FinalDecisionFurtherInformationRequired = 16,

    [Description("Final review by Ncc is in progress")]
    FinalReviewByNccInProgress = 17,

    [Description("Final review by Ncc approved")]
    FinalReviewByNccApproved = 18,

    [Description("Final review by Ncc declined")]
    FinalReviewByNccDeclined = 19,
    
    [Description("Admin Approved Ncc")]
    AdminApprovedNcc = 20,
    
    [Description("Admin Approved Site Visitor")]
    AdminApprovedSiteVisitor = 21,
    
    [Description("Admin Approved Final Ncc")]
    AdminApprovedFinalNcc = 22,
    
    [Description("Recertified")]
    Recertified = 23
}