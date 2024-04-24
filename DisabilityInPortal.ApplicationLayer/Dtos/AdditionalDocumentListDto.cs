using DisabilityInPortal.ApplicationLayer.Features.AdditionalDocuments.Queries.GetAdditionalDocumentById;
using System.Collections.Generic;

namespace DisabilityInPortal.ApplicationLayer.Features.AdditionalDocuments.Queries.GetAdditionalDocumentListById;

public class AdditionalDocumentListDto
{
    public int AdditionalDocumentListId { get; set; }
    public List<AdditionalDocumentDto> AdditionalDocuments { get; set; }

    public int ApplicationId { get; set; }
}