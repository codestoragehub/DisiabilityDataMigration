using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Enums
{
    public enum SectionReviewStatus
    {
        [Display(Name = "Complete")]
        Complete = 1,

        [Display(Name = "InComplete")]
        InComplete = 2,
    }
}
