using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Web;

namespace AzureCosmosResourceTokenGeneratorDemo
{
    public class CosmosHandler
    {

        public string GenerateAuthToken(
            string verb, ResourceType resourceType, string resourceId, 
            string date, string key, string keyType, string tokenVersion)
        {
            var hmacSha256 = new HMACSHA256
            { 
                Key = Convert.FromBase64String(key)
            };
            verb ??= "";
            var resourceTypeStr = ResourceType2String(resourceType);
            resourceId ??= "";
            var payLoad = String.Format(
                CultureInfo.InvariantCulture,
                "{0}\n{1}\n{2}\n{3}\n{4}\n",
                verb.ToLowerInvariant(),
                resourceTypeStr.ToLowerInvariant(),
                resourceId,
                date.ToLowerInvariant(),
                ""
            );
            var hashPayLoad = hmacSha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(payLoad));
            var signature = Convert.ToBase64String(hashPayLoad);
            return HttpUtility.UrlEncode(
                String.Format(
                    CultureInfo.InvariantCulture, "type={0}&ver={1}&sig={2}",
                    keyType,
                    tokenVersion,
                    signature));
        }

        public string ResourceType2String(ResourceType resourceType)
        {
            switch(resourceType)
            {
                case ResourceType.Database:
                    return "dbs";
                case ResourceType.Collection:
                    return "colls";
                case ResourceType.Document:
                    return "docs";
                default:
                    throw new NotImplementedException();
            }
        }

    }
}
