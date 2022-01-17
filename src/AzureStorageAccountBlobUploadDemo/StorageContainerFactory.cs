using Azure.Core;
using Azure.Storage.Blobs;
using System;

namespace AzureStorageAccountBlobUploadDemo
{
    public class StorageContainerFactory
    {

        private readonly BlobServiceClient blobServiceClient;

        private StorageContainerFactory(BlobServiceClient blobServiceClient)
        {
            this.blobServiceClient = blobServiceClient;
        }

        public static StorageContainerFactory UsingIdentity(string storageAccountName, TokenCredential tokenCredential)
        {
            var storageAccountUri = new Uri($"https://{storageAccountName}.blob.core.windows.net");
            var blobServiceClient = new BlobServiceClient(storageAccountUri, tokenCredential);
            return new StorageContainerFactory(blobServiceClient);
        }

        public static StorageContainerFactory UsingConnectionString(string connectionString)
        {
            var blobServiceClient = new BlobServiceClient(connectionString);
            return new StorageContainerFactory(blobServiceClient);
        }

        public StorageContainer GetContainer(string containerName)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            return new StorageContainer(containerClient);
        }

    }
}
