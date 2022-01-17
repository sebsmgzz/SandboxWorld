using Azure.Core;
using Azure.Identity;
using Azure.Storage.Blobs;
using System;

namespace AzureFunctionAppUserDelegationKeyDemo
{
    public static class Program
    {

        private static readonly TokenCredential credential;
        private static readonly Uri targetStorageAccountUri;

        public const string StorageAccountName = "";

        public const string ContainerName = "";

        static Program()
        {
            credential = new DefaultAzureCredential();
            targetStorageAccountUri = new Uri(
                $"https://{StorageAccountName}.blob.core.windows.net/{ContainerName}");
        }

        public static void Main(string[] args)
        {
            var blobContainerClient = new BlobContainerClient(
                targetStorageAccountUri, credential);
            var keyGenerator = new UserDelegationKeyGenerator(
                blobContainerClient);
            var key = keyGenerator.GetUserDelegationKeyAsync(
                TimeSpan.FromHours(1)).Result;
            Console.WriteLine(key.Value);
        }

    }
}
