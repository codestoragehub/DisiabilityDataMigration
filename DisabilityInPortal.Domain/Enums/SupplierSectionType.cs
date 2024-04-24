using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums;

public enum SupplierSectionType
{
    [Display(Name = "Basic Search")]
    BasicSearch = 1,

    [Display(Name = "Supplier Location")]
    SupplierLocation = 2,

    [Display(Name = "Company Information")]
    CompanyInformation = 3,

    [Display(Name = "Product Service Information")]
    ProductServiceInformation = 4,

    [Display(Name = "Diversity Classification")]
    DiversityClassification = 5,

    [Display(Name = "Business References")]
    BusinessReferences = 6
}