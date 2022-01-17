using Azure.Identity;
using System;
using System.Text.Json;

namespace AzureStorageAccountBlobUploadDemo
{
    public static class Program
    {

        private static readonly string AccountName = "";
        private static readonly string ContainerName = "";
        private static readonly string FilePath = @"";
        private static readonly string BlobPath = "example.txt";

        public static void Main(string[] args)
        {

            // Instantiate and do upload
            var credentials = new DefaultAzureCredential(true);
            var factory = StorageContainerFactory.UsingIdentity(AccountName, credentials);
            var container = factory.GetContainer(ContainerName);
            var result = container.UploadAsync(FilePath, BlobPath).Result;
            
            // Write result
            var jsonOptions = new JsonSerializerOptions();
            jsonOptions.WriteIndented = true;
            var json = JsonSerializer.Serialize(result, jsonOptions);
            Console.WriteLine(json);

        }

    }
}
