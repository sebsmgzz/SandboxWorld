using System;
using System.IO;
using System.Text.Json;

namespace AzureCosmosRestClientDemo
{
    public static class Program
    {

        public static string MasterKey = "masterKey";

        public static string CosmosAccountName = "accoutnName";
        
        public static string DatabaseName = "databaseName";

        public static string CollectionName = "collectionName";

        public static void Main(string[] args)
        {

            var endpointBuilder = new CosmosEndpointBuilder();
            var cosmosRequestBuilder = new CosmosRequestBuilder(endpointBuilder)
            {
                CosmosAccountName = CosmosAccountName,
                DatabaseName = DatabaseName,
                CollectionName = CollectionName
            };

            var document = new
            {
                id = Guid.NewGuid().ToString(),
                firstName = "Sarah",
                lastName = "Connor",
                value = "value"
            };

            var request = cosmosRequestBuilder.CreateDocument(MasterKey, document, document.firstName);
            Console.WriteLine($"{request.Method} {request.RequestUri}");
            
            for(int i = 0; i < request.Headers.Keys.Count; i++)
            {
                var key = request.Headers.Keys[i];
                var header = request.Headers[i];
                Console.WriteLine($"{key}: {header}");
            }

            using (var requestStream = request.GetRequestStream())
            {
                var docJsonStr = JsonSerializer.Serialize(document);
                Console.WriteLine(docJsonStr);
            }
            
            Console.WriteLine();
            var response = request.GetResponse();
            for (int i = 0; i < response.Headers.Count; i++)
            {
                var header = request.Headers[i];
                Console.WriteLine(header);
            }

            using (var responseStream = response.GetResponseStream())
            {
                using(var streamReader = new StreamReader(responseStream))
                {
                    Console.WriteLine(streamReader.ReadToEnd());
                }
            }

        }

    }
}
