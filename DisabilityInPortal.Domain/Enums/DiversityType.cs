using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Enums
{
    public enum DiversityType
    {        
        [Display(Name = "Disadvantaged Business Enterprise (DBE)")]
        DBE = 1,
        [Display(Name = "Small Disadvantaged Business (SDB)")]
        SDB = 2,
        [Display(Name = "Small Business Enterprise (SBE)")]
        SBE = 3,
        [Display(Name = "HubZone")]
        HubZone = 4,
        [Display(Name = "Women's Business Enterprise (WBE)")]
        WBE = 5,
        [Display(Name = "Service Disabled Veteran Owned Small Business(SDVOSB)")]
        SDVOSB = 6,
        [Display(Name = "Minority Business Enterprise (MBE)")]
        MBE = 7,
        [Display(Name = "LGBTBE")]
        LGBTBE = 8,
        [Display(Name = "SBA 8(A)")]
        SBA = 9,
        [Display(Name = "Other")]
        Other = 10,
    }   
}
