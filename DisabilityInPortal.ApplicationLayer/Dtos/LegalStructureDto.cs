
using DisabilityInPortal.ApplicationLayer.Features.LegalStructures.Queries.GetLegalStructureDocumentById;
using DisabilityInPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Features.LegalStructures.Queries.GetLegalStructureById
{
    public class LegalStructureDto
    {
        public int LegalStructureId { get; set; }
        public LegalStructureType LegalStructureType { get; set; }
        public string LegalStructureTypeOther { get; set; }
        public int? CompanyId { get; set; }
        public int ApplicationId { get; set; }
        public List<LegalStructureDocumentDto> LegalStructureDocuments  { get; set; }
    }
}
