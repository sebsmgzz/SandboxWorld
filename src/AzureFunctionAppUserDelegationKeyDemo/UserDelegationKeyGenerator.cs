using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using System;
using System.Threading.Tasks;

namespace AzureFunctionAppUserDelegationKeyDemo
{
    public class UserDelegationKeyGenerator
    {

        private readonly BlobContainerClient blobContainerClient;

        public UserDelegationKeyGenerator(BlobContainerClient blobContainerClient)
        {
            this.blobContainerClient = blobContainerClient;
        }

        public async Task<UserDelegationKey> GetUserDelegationKeyAsync(TimeSpan duration)
        {
            var blobServiceClient = blobContainerClient.GetParentBlobServiceClient();
            return await blobServiceClient.GetUserDelegationKeyAsync(
                DateTimeOffset.UtcNow.AddMinutes(-15),
                DateTimeOffset.UtcNow.AddTicks(duration.Ticks));
        }

    }
}
