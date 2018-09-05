using Cosmonaut;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionsRESTApi.Functions.CosmosDb
{
    public static class CosmosStoreFactory
    {
        public static ICosmosStore<T> GetCosmosStore<T>() where T : class
        {
            return new CosmosStore<T>(
                new CosmosStoreSettings(
                    Environment.GetEnvironmentVariable("CosmosDbDatabaseName"),
                    Environment.GetEnvironmentVariable("CosmosDbEndpoint"),
                    Environment.GetEnvironmentVariable("CosmosDbKey")
                )
            );
        }
    }
}
