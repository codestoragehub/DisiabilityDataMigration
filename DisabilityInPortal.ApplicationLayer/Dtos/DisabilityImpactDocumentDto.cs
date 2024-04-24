using DisabilityInPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Features.DisabilityImpacts.Dtos
{
    public class DisabilityImpactDocumentDto
    {
        public int DisabilityImpactDocumentId { get; set; }

        public int DisabilityImpactId { get; set; }

        public string Description { get; set; }
        public DisabilityImpactDocumentType DisabilityImpactDocumentType { get; set; }

        public int ApplicationId { get; set; }

        public int? DocumentId { get; set; }
    }
}
