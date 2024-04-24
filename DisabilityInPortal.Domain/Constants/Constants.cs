using System.Collections.Generic;
using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Models;

namespace DisabilityInPortal.Domain.Constants;

public static class Constants
{
    public const string DateFormat = "MM/dd/yyyy";
    public const string DateFormatSorting = "yyyyMMdd";
    public const string Title = "Disability:IN DOBE Portal";
    public const string BlobStorageContainerName = "application-files";

    public const int FetchSize = 50;
    public const string ApplicationReferencePrefix = "APP";
    public const string UserReferencePrefix = "USR";
    public const string PaymentReferencePrefix = "PAY";
    public const string InvoiceReferencePrefix = "INV";
    public const int ReferenceLength = 10;
    public const int ApplicantPage = 1;
    public const int AdminPage = 2;
    public const string ActiveRole = "ActiveRole";
    public const string IsReviewMode = "IsReviewMode";


    public const string SiteVisitorRole = "SiteVisitor";

    public static readonly IReadOnlyCollection<string> AdminRoles = new[]
    {
        nameof(Roles.SuperAdmin), nameof(Roles.Admin)
    };

    public static readonly IReadOnlyCollection<string> ManagementRoles = new[]
    {
        nameof(Roles.SuperAdmin), nameof(Roles.Admin), nameof(Roles.Ncc), nameof(Roles.SiteVisitor)
    };

    public static readonly IReadOnlyCollection<string> AssignmentRoles = new[]
    {
        nameof(Roles.Ncc), nameof(Roles.SiteVisitor)
    };

    public static readonly string[] AllowedDocumentFileTypes =
    {
        ".bmp", ".jpg", ".jpeg", ".png",
        ".doc", ".docx", ".odt", ".xls", ".xlsx", ".ods", ".csv", ".pdf", ".txt"
    };

    public static readonly IReadOnlyCollection<ApplicationStatus> ApplicationEditableStatuses = new[]
    {
        ApplicationStatus.Draft, ApplicationStatus.AdminSentBackToApplicant
    };

    public static readonly IReadOnlyCollection<ApplicationStatus> CertifiedApplicationStatuses = new[]
    {
        ApplicationStatus.Certified, ApplicationStatus.Recertified
    };

    // @formatter:off
    public static readonly List<HowDidYouHearAboutUsSetting> HowDidYouHearAboutUsSettings = new()
    {
        new HowDidYouHearAboutUsSetting {HowDidYouHearAboutUsType = HowDidYouHearAboutUsType.CommonwealthOfMassachusetts, HasReferredBy = false},
        new HowDidYouHearAboutUsSetting {HowDidYouHearAboutUsType = HowDidYouHearAboutUsType.CommonwealthOfPennsylvania, HasReferredBy = false},
        new HowDidYouHearAboutUsSetting {HowDidYouHearAboutUsType = HowDidYouHearAboutUsType.AnotherCertifiedDobe, HasReferredBy = true, ReferredByTitle = "Name of person or organization who referred you?"},
        new HowDidYouHearAboutUsSetting {HowDidYouHearAboutUsType = HowDidYouHearAboutUsType.AnotherDiverseSupplier, HasReferredBy = true, ReferredByTitle = "Name of person or organization who referred you?"},
        new HowDidYouHearAboutUsSetting {HowDidYouHearAboutUsType = HowDidYouHearAboutUsType.AnotherCertifyingOrganization, HasReferredBy = true, ReferredByTitle = "Name of person or organization who referred you?"},
        new HowDidYouHearAboutUsSetting {HowDidYouHearAboutUsType = HowDidYouHearAboutUsType.AnotherDisabilityAdvocacyOrganization, HasReferredBy = true, ReferredByTitle = "Name of person or organization who referred you?"},
        new HowDidYouHearAboutUsSetting {HowDidYouHearAboutUsType = HowDidYouHearAboutUsType.AVocationalRehabilitationCenter, HasReferredBy = true, ReferredByTitle = "Name of person or organization who referred you?"},
        new HowDidYouHearAboutUsSetting {HowDidYouHearAboutUsType = HowDidYouHearAboutUsType.AVeteransAdvocacyOrganization, HasReferredBy = true, ReferredByTitle = "Name of person or organization who referred you?"},
        new HowDidYouHearAboutUsSetting {HowDidYouHearAboutUsType = HowDidYouHearAboutUsType.InternetSearchDisabilityInWebsite, HasReferredBy = false },
        new HowDidYouHearAboutUsSetting {HowDidYouHearAboutUsType = HowDidYouHearAboutUsType.SocialMedia, HasReferredBy = true, ReferredByTitle = "Which media channel?" },
        new HowDidYouHearAboutUsSetting {HowDidYouHearAboutUsType = HowDidYouHearAboutUsType.DisabilityInAnnualConference, HasReferredBy = false},
        new HowDidYouHearAboutUsSetting {HowDidYouHearAboutUsType = HowDidYouHearAboutUsType.ADisabilityInAffiliate, HasReferredBy = true, ReferredByTitle = "Name of person or Disability:IN Affiliate?"},
        new HowDidYouHearAboutUsSetting {HowDidYouHearAboutUsType = HowDidYouHearAboutUsType.EventConference, HasReferredBy = true, ReferredByTitle = "Name of the event?"},
        new HowDidYouHearAboutUsSetting {HowDidYouHearAboutUsType = HowDidYouHearAboutUsType.ATradeBusinessOrganization, HasReferredBy = true, ReferredByTitle = "Name of person or organization who referred you?"},
        new HowDidYouHearAboutUsSetting {HowDidYouHearAboutUsType = HowDidYouHearAboutUsType.ACityStateFederalAgency, HasReferredBy = true, ReferredByTitle = "Name of person or agency who referred you?"},
        new HowDidYouHearAboutUsSetting {HowDidYouHearAboutUsType = HowDidYouHearAboutUsType.CurrentFormerCorporateClient, HasReferredBy = true, ReferredByTitle = "Name of person or organization who referred you?"},
        new HowDidYouHearAboutUsSetting {HowDidYouHearAboutUsType = HowDidYouHearAboutUsType.PotentialCorporateClient, HasReferredBy = true, ReferredByTitle = "Name of person or organization who referred you?"},
        new HowDidYouHearAboutUsSetting {HowDidYouHearAboutUsType = HowDidYouHearAboutUsType.ADisabilityInTeamMember, HasReferredBy = true, ReferredByTitle = "Name of person?"},
        new HowDidYouHearAboutUsSetting {HowDidYouHearAboutUsType = HowDidYouHearAboutUsType.FriendOrBusinessColleague, HasReferredBy = true, ReferredByTitle = "Name of person?"},
        new HowDidYouHearAboutUsSetting {HowDidYouHearAboutUsType = HowDidYouHearAboutUsType.Other, HasReferredBy = true, ReferredByTitle = "Please specify"}
    };
    // @formatter:on

    public static readonly List<HowDidYouHearAboutUsType> SkipPaymentReferrals = new()
    {
        HowDidYouHearAboutUsType.CommonwealthOfMassachusetts, HowDidYouHearAboutUsType.CommonwealthOfPennsylvania
    };

    public static readonly IReadOnlyCollection<ApplicationStatus> AdminReviewStatuses = new[]
    {
        ApplicationStatus.ApplicationSubmitted, ApplicationStatus.NccSentBackToAdmin, ApplicationStatus.NccApproved,
        ApplicationStatus.SiteVisitorDeclined, ApplicationStatus.SiteVisitorApproved,
        ApplicationStatus.SiteVisitorFurtherReviewRequired, ApplicationStatus.FinalDecisionDeclined,
        ApplicationStatus.FinalDecisionFurtherInformationRequired, ApplicationStatus.FinalReviewByNccApproved,
        ApplicationStatus.FinalReviewByNccDeclined
    };

    public static readonly IReadOnlyCollection<string> AnonymousList = new[]
    {
        "/Identity/Account/Login",
        "/Identity/Account/Register",
        "/Identity/Account/ForgotPassword",
        "/Identity/Account/ResendEmailConfirmation"
    };

    public static readonly IReadOnlyCollection<string> ApplicantList = new[]
    {
        "/Dashboard/Home/Index", "/Application/Manage/Update"
    };

    public static readonly IReadOnlyCollection<string> AdminList = new[]
    {
        "/Dashboard/Home/Index",
        "/Review/ApplicationReview/ApplicationReview",
        "/Search/Search/Search",
        "/Dashboard/Report"
    };

    public static readonly IReadOnlyCollection<string> NccList = new[]
    {
        "/Dashboard/Home/Index",
        "/Application/Manage/Update",
        "/Search/Search/Search"
    };

    public static readonly IReadOnlyCollection<string> SiteVisitorList = new[]
    {
        "/Dashboard/Home/Index", "/Application/Manage/Update", "/Search/Search/Search"
    };
}