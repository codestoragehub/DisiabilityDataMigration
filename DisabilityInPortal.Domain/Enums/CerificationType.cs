using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Enums
{
    public enum CerificationType
    {
        [Display(Name = "Disability Owned")]
        DisabilityOwned = 1,
        [Display(Name = "Service-Disability Veteran Owned")]
        ServiceDisabilityVeteranOwned = 2,
        [Display(Name = "Veteran-Disability Owned")]
        VeteranDisabilityOwned = 3,
    }
}
