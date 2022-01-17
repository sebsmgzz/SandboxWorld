using Microsoft.Azure.Cosmos;
using System;
using System.Text.Json;

namespace AzureCosmosDocumentUploadDemo
{
    public static class Program
    {

        private const string cosmosConnStr = 
            "AccountEndpoint=accountEndpoint;" +
            "AccountKey=secret;";
        private static CosmosClient _cosmosClient;

        private static CosmosClient CosmosClient
        {
            get
            {
                if(_cosmosClient == null)
                {
                    var options = new CosmosClientOptions()
                    {
                        ConnectionMode = ConnectionMode.Gateway
                    };
                    _cosmosClient = new CosmosClient(cosmosConnStr, options);
                }
                return _cosmosClient;
            }
        }

        public static void Main(string[] args)
        {
            // Create item
            var guid = Guid.NewGuid();
            var item = new
            {
                id = guid.ToString(),
                deviceID = guid.ToString(),
                TestValue = 143
            };
            Console.WriteLine(JsonSerializer.Serialize(item));
            var jsonItem = JsonSerializer.SerializeToUtf8Bytes(item);
            // Create handler
            var strategy = new ConfigLogStrategy();
            var handler = new CosmosHandler(CosmosClient, strategy);
            // Upload
            var response = handler.UploadAsync(jsonItem).Result;
            Console.WriteLine($"Status code: {response.StatusCode}");
            Console.WriteLine($"Resource: {response.Resource}");
        }

    }
}
