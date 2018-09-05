using AzureFunctionsRESTApi.Functions.Commands;
using AzureFunctionsRESTApi.Functions.CosmosDb;
using AzureFunctionsRESTApi.Functions.Handlers.Commands;
using AzureFunctionsRESTApi.Functions.Handlers.Queries;
using AzureFunctionsRESTApi.Functions.Model;
using AzureFunctionsRESTApi.Functions.Queries;
using Cosmonaut;
using Cosmonaut.Extensions;
using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;
using Microsoft.Extensions.DependencyInjection;
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

            builder
                .Setup((serviceCollection, commandRegistry) =>
                {
                    serviceCollection.AddSingleton((_) => CosmosStoreFactory.GetCosmosStore<Process>());

                    commandRegistry.Discover(this.GetType().Assembly);
                })
                .OpenApiEndpoint(openApi => openApi
                    .Title("Functions REST API")
                    .Version("0.0.0")
                    .UserInterface()
                )
                .Functions(functions => functions
                    .HttpRoute("/api/v1/process", route => route
                        .HttpFunction<GetProcessQuery>(HttpMethod.Get)
                        .HttpFunction<GetProcessByIdQuery>("/{id}", HttpMethod.Get)

                        .HttpFunction<CreateProcessCommand>(HttpMethod.Post)

                        .HttpFunction<MarkProcessAsSuccessfulCommand>("/succeeded", HttpMethod.Put)
                        .HttpFunction<MarkProcessAsFailedCommand>("/failed", HttpMethod.Put)
                    )
                );
        }
    }
}
