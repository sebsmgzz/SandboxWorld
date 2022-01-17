using System;

namespace AzureCosmosResourceTokenGeneratorDemo
{
    public static class Program
    {

        private const string MasterKey = "secret";

        public static string DatabaseName => "databaseName";

        public static string CollectionName => "collectionName";

        public static void Main(string[] args)
        {
            var timeStr = DateTime.UtcNow.ToString("r");
            Console.WriteLine(timeStr);
            var handler = new CosmosHandler();
            var token = handler.GenerateAuthToken(
                verb: "POST",
                resourceType: ResourceType.Document,
                resourceId: $"dbs/{DatabaseName}/colls/{CollectionName}",
                date: timeStr,
                key: MasterKey,
                keyType: "master",
                tokenVersion: "1.0");
            Console.WriteLine(token);
        }

    }
}
