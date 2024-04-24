using DisabilityInPortal.ApplicationLayer.Features.LegalStructures.Queries.GetLegalStructureById;
using DisabilityInPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Features.LegalStructures.Queries.GetLegalStructureDocumentById
{
    public class LegalStructureDocumentDto
    {
        public int? LegalStructureDocumentId { get; set; }
        public int LegalStructureDocumentTypeValue { get; set; }
        public string Description { get; set; }
        public int? DocumentId { get; set; }
        public int? CompanyId { get; set; }
        public LegalStructureType LegalStructureType { get; set; }
        public int LegalStructureId { get; set; }
        public LegalStructureDto LegalStructureDto { get; set; }
    }
}

