using System.Threading.Tasks;

namespace DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;

public interface IBlobStorageService
{
    Task DeleteAsync(string containerName, string fileName);
    Task<byte[]> DownloadAsync(string containerName, string fileName);
    Task<string> UploadAsync(byte[] bytes, string containerName, string fileName);
    Task TransferAzureBlobToAzureBlobAsync(string containerName, string sourceBlobName, string destinationBlobName);
}