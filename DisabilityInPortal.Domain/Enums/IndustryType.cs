using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums
{
    public enum IndustryType
    {
        None = 0,
        [Display(Name = "Agriculture")]
        Agriculture = 1,

        [Display(Name = "Architecture/Design")]
        ArchitectureDesign = 2,

        [Display(Name = "Biotechnology")]
        Biotechnology = 3,

        [Display(Name = "Commercial Services")]
        CommercialServices = 4,

        [Display(Name = "Consumer Services")]
        ConsumerServices = 5,

        [Display(Name = "Construction")]
        Construction = 6,

        [Display(Name = "Energy")]
        Energy = 7,

        [Display(Name = "Engineering")]
        Engineering = 8,

        [Display(Name = "Environmental")]
        Environmental = 9,

        [Display(Name = "Financial Services")]
        FinancialServices = 10,

        [Display(Name = "Food & Beverage")]
        FoodAndBeverage = 11,

        [Display(Name = "Healthcare")]
        Healthcare = 12,

        [Display(Name = "IT")]
        IT = 13,

        [Display(Name = "Legal")]
        Legal = 14,

        [Display(Name = "Manufacturing")]
        Manufacturing = 15,

        [Display(Name = "Marketing/Promotional")]
        MarketingPromotional = 16,

        [Display(Name = "Media")]
        Media = 17,

        [Display(Name = "Pharmaceutical")]
        Pharmaceutical = 18,

        [Display(Name = "Printing")]
        Printing = 19,

        [Display(Name = "Professional Services")]
        ProfessionalServices = 20,

        [Display(Name = "Professional Services – Accessibility Services")]
        ProfessionalServicesAccessibilityServices = 21,

        [Display(Name = "Professional Services – Consulting")]
        ProfessionalServicesConsulting = 22,

        [Display(Name = "Professional Services – HR")]
        ProfessionalServicesHR = 23,

        [Display(Name = "Professional Services – Staffing")]
        ProfessionalServicesStaffing = 24,

        [Display(Name = "Real Estate")]
        RealEstate = 25,

        [Display(Name = "Retail Trade")]
        RetailTrade = 26,

        [Display(Name = "Telecommunications")]
        Telecommunications = 27,

        [Display(Name = "Transportation/Logistics")]
        TransportationLogistics = 28,

        [Display(Name = "Wholesale/Warehouse")]
        WholesaleWarehouse = 29,

        [Display(Name = "Other")]
        Other = 30
    }
}
