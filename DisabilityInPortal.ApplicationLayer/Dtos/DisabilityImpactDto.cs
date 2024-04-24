
using DisabilityInPortal.Domain.Entities;
using System.Collections.Generic;

namespace DisabilityInPortal.ApplicationLayer.Features.DisabilityImpacts.Dtos
{
    public class DisabilityImpactDto
    {
        public int DisabilityImpactId { get; set; }        
        public string ApplicantInformation { get; set; }
        public int ApplicationId { get; set; }
        public List<DisabilityImpactDocumentDto> DisabilityImpactDocuments { get; set; }
    }
}
