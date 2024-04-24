using DisabilityInPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Features.Documents.Queries.GetDocumentListByCompanyId
{
    public class DocumentDto
    {
        public int? DocumentId { get; set; }
        public int ApplicationId { get; set; }
        public string FileName { get; set; }
        public int? CompanyId { get; set; }
        public DocumentType Type { get; set; }
    }
}
