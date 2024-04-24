using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.Domain.Enums
{
    public enum EquipmentType
    {
        [Display(Name = "None")]
        None = 0,

        [Display(Name = "Type1")]
        Type1 = 1

    }
}
