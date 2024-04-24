using System.Globalization;
using System.IO;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;
using DisabilityInPortal.Domain.Entities;
using DisabilityInPortal.Domain.Extensions;

namespace DisabilityInPortal.ApplicationLayer.Common.Services;

public class BlobNameProvider : IBlobNameProvider
{
    private readonly IIdentityService _identityService;

    public BlobNameProvider(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public string Get(Document document)
    {
        var user = _identityService.GetUserById(document.UserId);
        var userEmail = user.Email;
        var applicationIdString = FormatId(document.ApplicationId);
        var typeString = document.Type.GetBlobString();
        var documentIdString = FormatId(document.DocumentId);
        var fileExtension = (Path.GetExtension(document.FileName) ?? "unknown").ToLowerInvariant();

        return $"{userEmail}/application-{applicationIdString}/{typeString}/document-{documentIdString}{fileExtension}";
    }

    public string GetSupplierProfileDocument(SupplierProfileDocument document)
    {
        var user = _identityService.GetUserById(document.UserId);
        var userEmail = user.Email;
        var supplierProfileIdString = FormatId(document.SupplierProfileId);
        var typeString = document.Type.GetBlobString();
        var documentIdString = FormatId(document.SupplierProfileDocumentId);
        var fileExtension = (Path.GetExtension(document.FileName) ?? "unknown").ToLowerInvariant();

        return $"{userEmail}/supplierProfile/{typeString}/document-{documentIdString}{fileExtension}";
    }
    private static string FormatId(int id)
    {
        return id.ToString(CultureInfo.InvariantCulture);
    }
}