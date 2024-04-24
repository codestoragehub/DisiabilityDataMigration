using DisabilityInPortal.Domain.Enums;

namespace DisabilityInPortal.ApplicationLayer.Features.AdditionalDocuments.Queries.GetAdditionalDocumentById;

public class AdditionalDocumentDto
{
    public int AdditionalDocumentId { get; set; }
    public string Description { get; set; }
    public AdditionalDocumentType Type { get; set; }
    public int? DocumentId { get; set; }
    public int AdditionalDocumentListId { get; set; }
    public int ApplicationId { get; internal set; }
}