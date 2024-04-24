using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DisabilityInPortal.Domain.Entities.Common;

namespace DisabilityInPortal.Domain.Entities;

[Table("AdditionalDocumentLists")]
public class AdditionalDocumentList : AuditBaseEntity
{
    public AdditionalDocumentList()
    {
        AdditionalDocuments = new List<AdditionalDocument>();
    }

    public int AdditionalDocumentListId { get; set; }
    public List<AdditionalDocument> AdditionalDocuments { get; set; }

    public int ApplicationId { get; set; }
    public Application Application { get; set; }
}