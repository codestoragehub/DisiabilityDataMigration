using System.IO;
using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;
using DisabilityInPortal.ApplicationLayer.Features.Documents.Queries.GetDocumentById;
using DisabilityInPortal.Domain.Constants;
using DisabilityInPortal.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace DisabilityInPortal.ApplicationLayer.Common.Services;

public class DocumentFileService : IDocumentFileService
{
    private readonly IBlobNameProvider _blobNameProvider;
    private readonly IBlobStorageService _blobService;

    public DocumentFileService(
        IBlobStorageService blobService,
        IBlobNameProvider blobNameProvider)
    {
        _blobService = blobService;
        _blobNameProvider = blobNameProvider;
    }

    public async Task<FileDto> GetFileAsync(Document document)
    {
        var blobName = _blobNameProvider.Get(document);
        var file = await _blobService.DownloadAsync(Constants.BlobStorageContainerName, blobName);

        return new FileDto
        {
            FileName = document.FileName,
            File = file
        };
    }   

    public Task<string> CreateNewFileAsync(Document document, byte[] file)
    {
        var blobName = _blobNameProvider.Get(document);

        return _blobService.UploadAsync(file, Constants.BlobStorageContainerName, blobName);
    }

    public Task<string> CreateNewFileAsync(Document document, IFormFile file)
    {
        var bytes = GetBytes(file);

        return CreateNewFileAsync(document, bytes);
    }

    public Task DeleteFileAsync(Document document)
    {
        var blobName = _blobNameProvider.Get(document);

        return _blobService.DeleteAsync(Constants.BlobStorageContainerName, blobName);
    }

    public Task TransferAzureBlobToAzureBlobAsync(Document source, Document target)
    {
        var sourceBlobName = _blobNameProvider.Get(source);
        var targetBlobName = _blobNameProvider.Get(target);

        return _blobService.TransferAzureBlobToAzureBlobAsync(
            Constants.BlobStorageContainerName,
            sourceBlobName,
            targetBlobName);
    }

    public Task TransferDocumentAzureBlobToSupplierDocumentAzureBlobAsync(Document source, SupplierProfileDocument target)
    {
        var sourceBlobName = _blobNameProvider.Get(source);
        var targetBlobName = _blobNameProvider.GetSupplierProfileDocument(target);

        return _blobService.TransferAzureBlobToAzureBlobAsync(
            Constants.BlobStorageContainerName,
            sourceBlobName,
            targetBlobName);
    }

    private static byte[] GetBytes(IFormFile file)
    {
        using var target = new MemoryStream();
        file.CopyTo(target);
        return target.ToArray();
    }
}