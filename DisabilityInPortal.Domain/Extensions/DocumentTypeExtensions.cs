using System;
using System.ComponentModel;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.Domain.Extensions;

public static class DocumentTypeExtensions
{
    public static string GetBlobString(this DocumentType type)
    {
        return type switch
        {
            DocumentType.FranchiseAgreement => "FranchiseAgreement",
            DocumentType.CertificationAgency => "CertificationAgency",
            DocumentType.RentalPurchaseAgreement => "RentalPurchaseAgreement",
            DocumentType.LegalStructureGoverningDocument => "LegalStructureGoverningDocument",
            DocumentType.LicenseCertification => "LicenseCertification",
            DocumentType.ExecutedTrustDocumentation => "ExecutedTrustDocumentation",
            DocumentType.PictureId => "PictureId",
            DocumentType.Passport => "Passport",
            DocumentType.EquipmentPurchaseAgreement => "EquipmentPurchaseAgreement",
            DocumentType.VehiclePurchaseAgreement => "VehiclePurchaseAgreement",
            DocumentType.Resume => "Resume",
            DocumentType.SigningAuthority => "SigningAuthority",
            DocumentType.Lawsuit => "Lawsuit",
            DocumentType.Bankruptcy => "Bankruptcy",
            DocumentType.CertificationDenial => "CertificationDenial",
            DocumentType.SiteVisitAccomodationRequirements => "SiteVisitAccomodationRequirements",
            DocumentType.DiversityCertificate => "DiversityCertificate",
            DocumentType.DisabilityImpact => "DisabilityImpact",
            DocumentType.W2Or1099Form => "W2Or1099Form",
            DocumentType.BankAndCreditReference => "BankAndCreditReference",
            DocumentType.BusinessRelationshipDocument => "BusinessRelationshipDocument",
            DocumentType.EmployeesList => "EmployeesList",
            DocumentType.ProfitLossStatement => "ProfitLossStatement",
            DocumentType.BalanceSheet => "BalanceSheet",
            DocumentType.ManagementChange => "ManagementChange",
            DocumentType.AdditionalDocument => "AdditionalDocument",
            DocumentType.DefenceForm214 => "DefenceForm214",
            DocumentType.DisabilityRatingsLetter => "DisabilityRatingsLetter",
            DocumentType.DisabilityStatement => "DisabilityStatement",
            DocumentType.IndividualizedEducationProgram => "IndividualizedEducationProgram",
            DocumentType.DisabilityBenefits => "DisabilityBenefits",
            DocumentType.DisabilityINPhysicianForm => "DisabilityINPhysicianForm",
            DocumentType.TransportationContract => "TransportationContract",
            DocumentType.TransportationLease => "TransportationLease",
            DocumentType.LoanAgreement => "LoanAgreement",
            DocumentType.RecentItemizedPayRoll => "RecentItemizedPayRoll",
            DocumentType.SsdStatement => "SsdStatement",
            DocumentType.SsiStatement => "SsiStatement",
            DocumentType.FederalTaxReturn => "FederalTaxReturn",
            DocumentType.ContractReference => "ContractReference",
            DocumentType.VaVerificationLetter => "VaVerificationLetter",
            DocumentType.None => throw new InvalidEnumArgumentException("Document type cannot be None."),
            _ => throw new NotImplementedException($"Blob name for document type {type} not handled.")
        };
    }
}