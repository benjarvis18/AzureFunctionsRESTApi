using AzureFunctionsRESTApi.Functions.Commands;
using AzureFunctionsRESTApi.Functions.Handlers.Commands;
using AzureFunctionsRESTApi.Functions.Model;
using Cosmonaut;
using Cosmonaut.Extensions;
using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AzureFunctionsRESTApi.Functions
{
    public class FunctionAppConfiguration : IFunctionAppConfiguration
    {
        public void Build(IFunctionHostBuilder builder)
        {
            JsonConvert.DefaultSettings = () =>
            {
                return new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                };
            };

            var cosmosSettings = new CosmosStoreSettings(
                "Logging",
                "https://localhost:8081",
                "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw=="
            );

            builder
                .Setup((serviceCollection, commandRegistry) =>
                {
                    serviceCollection.AddCosmosStore<Process>(cosmosSettings);

                    commandRegistry.Register<CreateProcessCommandHandler>();
                    commandRegistry.Register<MarkProcessAsSuccessfulCommandHandler>();
                    commandRegistry.Register<MarkProcessAsFailedCommandHandler>();
                })
                .OpenApiEndpoint(openApi => openApi
                    .Title("Functions REST API")
                    .Version("0.0.0")
                    .UserInterface()
                )
                .Functions(functions => functions
                    .HttpRoute("/api/v1/process", route => route
                        .HttpFunction<CreateProcessCommand>(HttpMethod.Post)
                    )
                    .HttpRoute("/api/v1/process/{id}/successful", route => route
                        .HttpFunction<MarkProcessAsSuccessfulCommand>(HttpMethod.Put)
                    )
                    .HttpRoute("/api/v1/process/{id}/failed", route => route
                        .HttpFunction<MarkProcessAsFailedCommand>(HttpMethod.Put)
                    )
                );
        }
    }
}
