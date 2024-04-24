using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage.DataMovement;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DisabilityInPortal.Infrastructure.Services;

public class BlobStorageService : IBlobStorageService
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<BlobStorageService> _logger;

    public BlobStorageService(
        BlobServiceClient blobServiceClient,
        IConfiguration configuration,
        ILogger<BlobStorageService> logger)
    {
        _blobServiceClient = blobServiceClient;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<string> UploadAsync(byte[] bytes, string containerName, string fileName)
    {
        var client = await GetClientAsync(containerName, fileName);

        await using var ms = new MemoryStream(bytes, false);
        await client.UploadAsync(ms, true);

        return client.Uri.AbsoluteUri;
    }

    public async Task<byte[]> DownloadAsync(string containerName, string fileName)
    {
        var client = await GetClientAsync(containerName, fileName);

        var downloadContent = await client.DownloadAsync();

        await using var ms = new MemoryStream();
        await downloadContent.Value.Content.CopyToAsync(ms);

        return ms.ToArray();
    }

    public async Task DeleteAsync(string containerName, string fileName)
    {
        var client = await GetClientAsync(containerName, fileName);

        await client.DeleteAsync();
    }

    public async Task TransferAzureBlobToAzureBlobAsync(
        string containerName,
        string sourceBlobName,
        string destinationBlobName)
    {
        try
        {
            var account = CloudStorageAccount.Parse(_configuration.GetConnectionString("AzureBlobStorage"));

            var sourceBlobClient = account.CreateCloudBlobClient();
            var sourceBlobContainer = sourceBlobClient.GetContainerReference(containerName);
            var sourceBlob = sourceBlobContainer.GetBlockBlobReference(sourceBlobName);

            var destBlobClient = account.CreateCloudBlobClient();
            var destBlobContainer = destBlobClient.GetContainerReference(containerName);
            var destBlob = destBlobContainer.GetBlockBlobReference(destinationBlobName);

            TransferManager.Configurations.ParallelOperations = 8;
            var context = new SingleTransferContext();

            await TransferManager.CopyAsync(
                sourceBlob,
                destBlob,
                CopyMethod.ServiceSideSyncCopy,
                null,
                context,
                CancellationToken.None);
        }
        catch (Exception e)
        {
            _logger.LogError(
                e,
                "TransferAzureBlobToAzureBlob error. Source: {SourceBlobName}, Destination: {DestinationBlobName}",
                sourceBlobName,
                destinationBlobName);
        }
    }

    private async Task<BlobClient> GetClientAsync(string containerName, string fileName)
    {
        var container = _blobServiceClient.GetBlobContainerClient(containerName);

        // Explicitly checking for the container's existence before calling CreateIfNotExists is a workaround for a known SDK issue.
        // Logs to Application Insights as error for no reason
        if (!await container.ExistsAsync())
            await container.CreateIfNotExistsAsync();

        return container.GetBlobClient(fileName);
    }
}