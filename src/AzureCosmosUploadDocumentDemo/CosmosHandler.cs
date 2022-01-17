using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCosmosDocumentUploadDemo
{
    public class CosmosHandler
    {

        private readonly CosmosClient cosmosClient;
        private readonly ICosmosStrategy cosmosStrategy;

        public CosmosHandler(CosmosClient cosmosClient, ICosmosStrategy cosmosStrategy)
        {
            this.cosmosClient = cosmosClient;
            this.cosmosStrategy = cosmosStrategy;
        }

        public async Task<ItemResponse<JObject>> UploadAsync(byte[] jsonBytes)
        {
            var container = cosmosClient.GetContainer(
                cosmosStrategy.DatabaseName, cosmosStrategy.ContainerName);
            var jsonString = Encoding.UTF8.GetString(jsonBytes);
            var item = JsonConvert.DeserializeObject<dynamic>(jsonString);
            var partitionKey = cosmosStrategy.GetPartitionKey(item);
            return await container.CreateItemAsync(item, partitionKey);
        }

    }
}
