using System.Collections.Generic;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.Domain.Constants;

public static class CertificationAgencies
{
    // @formatter:off
    public static readonly List<CertificationAgency> Data = new()
    {
        new CertificationAgency { CertificationAgencyId = 1, Name = "NGLCC", IsDocumentRequired = true, DocumentType = DocumentType.CertificationAgency, IsUsOrganisation = true },
        new CertificationAgency { CertificationAgencyId = 2, Name = "WBENC", IsDocumentRequired = true, DocumentType = DocumentType.CertificationAgency, IsUsOrganisation = true },
        new CertificationAgency { CertificationAgencyId = 3, Name = "WEConnect International (Global)", IsDocumentRequired = false, IsInternationalOrganisation = true },
        new CertificationAgency { CertificationAgencyId = 4, Name = "NMSDC", IsDocumentRequired = true, DocumentType = DocumentType.CertificationAgency, IsUsOrganisation = true },
        new CertificationAgency { CertificationAgencyId = 6, Name = "NAVOBA", IsDocumentRequired = true, DocumentType = DocumentType.CertificationAgency, IsUsOrganisation = true },
        new CertificationAgency { CertificationAgencyId = 7, Name = "MSDUK (United Kingdom)", IsDocumentRequired = false, IsInternationalOrganisation = true },
        new CertificationAgency { CertificationAgencyId = 8, Name = "CAMSC (Canada)", IsDocumentRequired = false, IsInternationalOrganisation = true },
        new CertificationAgency { CertificationAgencyId = 9, Name = "Supply Nation (Australia)", IsDocumentRequired = false, IsInternationalOrganisation = true },
        new CertificationAgency { CertificationAgencyId = 10, Name = "SASDC (South Africa)", IsDocumentRequired = false, IsInternationalOrganisation = true },
        new CertificationAgency { CertificationAgencyId = 11, Name = "Integrare (Brazil)", IsDocumentRequired = false, IsInternationalOrganisation = true },
        new CertificationAgency { CertificationAgencyId = 12, Name = "CVE - VA VERIFIED", IsDocumentRequired = true, DocumentType = DocumentType.VaVerificationLetter, IsUsOrganisation = true }
    };
    // @formatter:on
}