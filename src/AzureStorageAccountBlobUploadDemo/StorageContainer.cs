using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.IO;
using System.Threading.Tasks;

namespace AzureStorageAccountBlobUploadDemo
{
    public class StorageContainer
    {

        private readonly BlobContainerClient client;

        public StorageContainer(BlobContainerClient client)
        {
            this.client = client;
        }

        public async Task<BlobContentInfo> UploadAsync(string filePath, string blobPath)
        {
            var blobClient = client.GetBlobClient(blobPath);
            using (var stream = File.OpenRead(filePath))
            {
                var response = await blobClient.UploadAsync(stream);
                return response.Value;
            }
        }

    }
}
