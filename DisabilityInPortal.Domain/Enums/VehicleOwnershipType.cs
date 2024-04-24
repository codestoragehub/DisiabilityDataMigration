using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Enums
{
    public enum VehicleOwnershipType
    {
        [Display(Name = "None")]
        None = 0,

        [Display(Name = "Owned")]
        Owner = 1,

        [Display(Name = "Lease")]
        Lease = 2
    }
}
