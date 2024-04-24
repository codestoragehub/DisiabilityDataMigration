using System.ComponentModel;

namespace DisabilityInPortal.Domain.Enums;

public enum ApplicationWorkflowAction
{
    [Description("N/A")]
    None = 0,

    [Description("Applicant Submit")]
    ApplicantSubmit = 1,

    [Description("Admin Started Review")]
    AdminStartedReview = 2,

    [Description("Admin Approve")]
    AdminApprove = 3,

    [Description("Admin Decline")]
    AdminDecline = 4,

    [Description("Ncc Started Review")]
    NccStartedReview = 5,

    [Description("Ncc Approve")]
    NccApprove = 6,

    [Description("Ncc Decline")]
    NccDecline = 7,

    [Description("Site Visitor Started Review")]
    SiteVisitorStartedReview = 8,

    [Description("Site Visitor Approve")]
    SiteVisitorApprove = 9,

    [Description("Site Visitor Decline")]
    SiteVisitorDecline = 10,

    [Description("Site Visitor Requires Further Review")]
    SiteVisitorRequiresFurtherReview = 11,

    [Description("Final Decision Review")]
    FinalDecisionReview = 12,

    [Description("Final Decision Approve")]
    FinalDecisionApprove = 13,

    [Description("FinalcDecisioncDecline")]
    FinalDecisionDecline = 14,

    [Description("Final Decision Requires Further Information")]
    FinalDecisionRequiresFurtherInformation = 15,

    [Description("Re Opened by Admin")]
    AdminReOpenApplication = 16,

    [Description("Re Opened by Admin")]
    NccFinalApprove = 17,

    [Description("Re Opened by Admin")]
    NccFinalDecline = 18,

    [Description("Re Opened by Admin")]
    AdminApproveNcc = 19,

    [Description("Re Opened by Admin")]
    AdminApproveSiteVisitor = 20,

    [Description("Re Opened by Admin")]
    AdminApproveFinalNcc = 21
}