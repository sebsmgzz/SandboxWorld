using System;

namespace AzureCosmosRestClientDemo
{
    public class CosmosEndpointBuilder
    {

        public Uri GetCreateDocumentEndpoint(
            string cosmosAccountName, string databaseName, string collectionName)
        {
            return new Uri($"https://{cosmosAccountName}.documents.azure.com" +
                $"/dbs/{databaseName}" +
                $"/colls/{collectionName}" +
                $"/docs");
        }
    
    }
}
