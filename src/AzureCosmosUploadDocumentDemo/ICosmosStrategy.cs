using Microsoft.Azure.Cosmos;

namespace AzureCosmosDocumentUploadDemo
{
    public interface ICosmosStrategy
    {

        public string DatabaseName { get; }

        public string ContainerName { get; }

        PartitionKey GetPartitionKey(dynamic item);

    }
}
