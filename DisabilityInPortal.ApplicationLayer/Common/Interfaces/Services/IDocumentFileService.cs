using System.Threading.Tasks;
using DisabilityInPortal.ApplicationLayer.Features.Documents.Queries.GetDocumentById;
using DisabilityInPortal.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;

public interface IDocumentFileService
{
    Task<FileDto> GetFileAsync(Document document);
    Task<string> CreateNewFileAsync(Document document, byte[] file);
    Task<string> CreateNewFileAsync(Document document, IFormFile file);
    Task DeleteFileAsync(Document document);
    Task TransferAzureBlobToAzureBlobAsync(Document source, Document target);
    Task TransferDocumentAzureBlobToSupplierDocumentAzureBlobAsync(Document source, SupplierProfileDocument target);
}