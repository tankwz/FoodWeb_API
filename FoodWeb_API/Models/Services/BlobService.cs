using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Net.Mime;

namespace FoodWeb_API.Models.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobClient;
        public BlobService(BlobServiceClient blobClient)
        {
             _blobClient = blobClient;
        }
        public async Task<bool> DeleteBlob(string blobName, string containerName)
        {
            BlobContainerClient container = _blobClient.GetBlobContainerClient(containerName);
            BlobClient client = container.GetBlobClient(blobName);
            return await client.DeleteIfExistsAsync();
        }

        public async Task<string> GetBlob(string blobName, string containerName)
        {
            BlobContainerClient container = _blobClient.GetBlobContainerClient(containerName);
            BlobClient client = container.GetBlobClient(blobName);
            return  client.Uri.AbsoluteUri;
        }

        public async Task<string> UploadBlob(string blobName, string containerName, IFormFile img)
        {
            BlobContainerClient container = _blobClient.GetBlobContainerClient(containerName);
            BlobClient client = container.GetBlobClient(blobName);
            var httpHeaders = new BlobHttpHeaders()
            {
                ContentType = img.ContentType
            };
            var result = await client.UploadAsync(img.OpenReadStream(), httpHeaders);
            if(result!=null)
            {
                return await GetBlob(blobName, containerName);
            }
            return "";
        }
    }
}
