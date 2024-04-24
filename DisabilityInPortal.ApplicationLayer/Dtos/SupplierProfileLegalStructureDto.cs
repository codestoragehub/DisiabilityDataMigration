using DisabilityInPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Features.SupplierProfiles.Dtos
{
    public class SupplierProfileLegalStructureDto
    {
        public int SupplierProfileLegalStructureId { get; set; }
        public LegalStructureType LegalStructureType { get; set; }
        public string LegalStructureTypeOther { get; set; }
        public int SupplierProfileId { get; set; }
    }
}
