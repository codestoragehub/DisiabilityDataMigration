using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;
using DisabilityInPortal.Domain.Enums;
using DisabilityInPortal.Domain.Helpers;
using DisabilityInPortal.Domain.Identity;

namespace DisabilityInPortal.Domain.Entities;

[Table("Applications")]
public class Application : AuditBaseEntity
{
    public Application()
    {
        ApplicationCreatedDate = DateTimeOffset.UtcNow;
        ApplicationStatus = Enums.ApplicationStatus.Draft;

        AdditionalDocumentList = new AdditionalDocumentList();
        AdditionalInformation = new AdditionalInformation();
        Affidavit = new Affidavit();
        Capability = new Capability();
        Company = new Company();
        DisabilityImpact = new DisabilityImpact();
        FinancialSizeInfo = new FinancialSizeInfo();
        ManagementAtOutsideFirm = new ManagementAtOutsideFirm();
        ManagementChange = new ManagementChange();
        ManagementResponsibility = new ManagementResponsibility();
        PaymentDetail = new PaymentDetail();
        RealEstate = new RealEstate();
        TransportationDetail = new TransportationDetail();
        TrustDetail = new TrustDetail();

        AddressList = new List<Address>();
        ApplicationCertificationAgencies = new List<ApplicationCertificationAgency>();
        BankAndCreditReferences = new List<BankAndCreditReference>();
        BusinessRelationships = new List<BusinessRelationship>();
        ContractReferenceList = new List<ContractReference>();
        DiversityList = new List<Diversity>();
        Equipments = new List<Equipment>();
        ManagementContributions = new List<ManagementContribution>();
        Owners = new List<Owner>();
        Vehicles = new List<Vehicle>();
    }

    public int ApplicationId { get; set; }
    public int? ClonedFromApplicationId { get; set; }

    public string ApplicationReference { get; private set; }

    public int? HowDidYouHearAboutUs { get; set; }

    public string ReferredBy { get; set; }

    public DateTimeOffset? ApplicationCreatedDate { get; set; }
    public DateTimeOffset? ApplicationSubmittedDate { get; set; }
    public DateTimeOffset? ApplicationApprovedDate { get; set; }
    public DateTimeOffset? ApplicationExpirationDate { get; set; }

    public ApplicationStatus? ApplicationStatus { get; set; }

    public string UserId { get; set; }

    [ForeignKey("UserId")]
    public ApplicationUser ApplicationUser { get; set; }

    public int? CompanyId { get; set; }

    [ForeignKey("CompanyId")]
    public Company Company { get; set; }

    public List<ApplicationCertificationAgency> ApplicationCertificationAgencies { get; set; }

    public RealEstate RealEstate { get; set; }
    public TrustDetail TrustDetail { get; set; }
    public TransportationDetail TransportationDetail { get; set; }
    public AdditionalInformation AdditionalInformation { get; set; }
    public Affidavit Affidavit { get; set; }
    public Capability Capability { get; set; }
    public List<ManagementContribution> ManagementContributions { get; set; }
    public ManagementResponsibility ManagementResponsibility { get; set; }
    public ManagementAtOutsideFirm ManagementAtOutsideFirm { get; set; }
    public AdditionalDocumentList AdditionalDocumentList { get; set; }
    public DisabilityImpact DisabilityImpact { get; set; }
    public FinancialSizeInfo FinancialSizeInfo { get; set; }
    public ManagementChange ManagementChange { get; set; }
    public List<BankAndCreditReference> BankAndCreditReferences { get; set; }
    public List<BusinessRelationship> BusinessRelationships { get; set; }
    public List<Diversity> DiversityList { get; set; }
    public List<ContractReference> ContractReferenceList { get; set; }
    public List<Address> AddressList { get; set; }
    public PaymentDetail PaymentDetail { get; set; }
    public Invoice Invoice { get; set; }
    public List<Equipment> Equipments { get; set; }
    public List<Vehicle> Vehicles { get; set; }
    public List<Owner> Owners { get; set; }
    public List<ApplicationAssignee> ApplicationAssignees { get; set; }

    public static string GenerateApplicationReference()
    {
        return ReferenceHelper.CreateReference(
            Constants.Constants.ApplicationReferencePrefix,
            Constants.Constants.ReferenceLength);
    }

    public void SetApplicationReference(string applicationReference)
    {
        if (!string.IsNullOrWhiteSpace(ApplicationReference))
            return;

        ApplicationReference = applicationReference;
    }
}