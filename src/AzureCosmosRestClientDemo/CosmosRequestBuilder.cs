using System.Net;
using System.Text;
using System.Text.Json;

namespace AzureCosmosRestClientDemo
{
    public class CosmosRequestBuilder
    {

        private readonly CosmosEndpointBuilder endpointBuilder;

        public string HostName => $"{CosmosAccountName}.documents.azure.com";

        public string CosmosAccountName { get; set; }

        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }

        public CosmosRequestBuilder(CosmosEndpointBuilder endpointBuilder)
        {
            this.endpointBuilder = endpointBuilder;
        }

        public WebRequest CreateDocument(string masterKey, dynamic document, params string[] partitionKeys)
        {
            var uri = endpointBuilder.GetCreateDocumentEndpoint(
                CosmosAccountName, DatabaseName, CollectionName);
            var request = WebRequest.Create(uri);
            request.Method = "POST";
            request.Headers.Add("authorization", $"type%3dmaster%26ver%3d1.0%26sig%3d{masterKey}%3d");
            request.Headers.Add("x-ms-date", "Thu, 26 Aug 2021 23:58:04 GMT");
            request.Headers.Add("x-ms-version", "2017-01-19");
            request.Headers.Add("x-ms-documentdb-partitionkey", GetPartitionKey(partitionKeys));
            request.Headers.Add("Host", HostName);
            request.ContentType = "application/json";
            using (var requestStream = request.GetRequestStream())
            {
                var docJsonStr = JsonSerializer.Serialize(document);
                var docJsonBytes = Encoding.UTF8.GetBytes(docJsonStr);
                request.ContentLength = docJsonBytes.Length;
                requestStream.Write(docJsonBytes, 0, docJsonBytes.Length);
            }
            return request;
        }

        public string GetPartitionKey(params string[] partitionKeys)
        {
            var builder = new StringBuilder();
            foreach (string partitionKey in partitionKeys)
            {
                builder.Append("\"").Append(partitionKey).Append("\"");
            }
            return $"[{builder}]";
        }

    }
}
