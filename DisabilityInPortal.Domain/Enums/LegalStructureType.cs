using System.ComponentModel.DataAnnotations;

namespace DisabilityInPortal.Domain.Enums
{
    public enum LegalStructureType
    {
        [Display(Name = "None")]
        None = 0,

        [Display(Name = "C-Corporation")]
        C_Corporation = 1,

        [Display(Name = "S-Corporation")]
        S_Corporation = 2,

        [Display(Name = "LLC/L3C Single Member")]
        LLCOrL3CSingleMember = 3,

        [Display(Name = "LLC/L3C Multi-Member")]
        LLCOrL3CMultiMember = 4,

        [Display(Name = "Partnership")]
        Partnership = 5,

        [Display(Name = "Sole Proprietor")]
        SoleProprietor = 6,

        [Display(Name = "Other")]
        Other = 7,

    }
}
