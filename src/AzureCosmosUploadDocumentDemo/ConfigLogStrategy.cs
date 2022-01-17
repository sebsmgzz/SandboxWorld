using Microsoft.Azure.Cosmos;
using System;

namespace AzureCosmosDocumentUploadDemo
{
    public class ConfigLogStrategy : ICosmosStrategy
    {

        public string DatabaseName { get; }

        public string ContainerName { get; } 

        public ConfigLogStrategy()
        {
            DatabaseName = "VascularDatabase";
            ContainerName = "ConfigContainer";
        }

        public PartitionKey GetPartitionKey(dynamic item)
        {
            return new PartitionKey(
                item.id.ToString());
        }

    }
}
