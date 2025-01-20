using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace PortalRh
{
    public class FileService
    {
        private string connectionString = @"DefaultEndpointsProtocol=https;AccountName=pruebacona;AccountKey=EzjhSdznquGSLVYYKCAEBiRsxM1OMpKF/wJbcw+xHEpsDEdBukBS+Ea7CcNKW9Lfs8G6QFiPCCCv+AStUCZEMg==;EndpointSuffix=core.windows.net";

        public async Task<string> SaveFile(string containerName, IFormFile file)
        {
            containerName = "almacenar";
            BlobContainerClient blobClientContainer = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = blobClientContainer.GetBlobClient(file.FileName);
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream);
            var path = blobClient.Uri.AbsoluteUri;
            return path;
        }

        public async Task<List<string>> ListBlobs(string containerName)
        {
            var blobClientContainer = new BlobContainerClient(connectionString, containerName);
            var blobItems = new List<string>();

            await foreach (BlobItem blobItem in blobClientContainer.GetBlobsAsync())
            {
                blobItems.Add(blobItem.Name);
            }

            return blobItems;
        }

        
        public async Task<Stream> DownloadBlob(string containerName, string blobName)
        {
            var blobClientContainer = new BlobContainerClient(connectionString, containerName);
            var blobClient = blobClientContainer.GetBlobClient(blobName);
            var downloadResponse = await blobClient.DownloadAsync();
            return downloadResponse.Value.Content;
        }
    }
}
