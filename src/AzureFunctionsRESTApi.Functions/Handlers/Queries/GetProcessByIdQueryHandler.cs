using AzureFromTheTrenches.Commanding.Abstractions;
using AzureFunctionsRESTApi.Functions.Model;
using AzureFunctionsRESTApi.Functions.Queries;
using Cosmonaut;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsRESTApi.Functions.Handlers.Queries
{
    public class GetProcessByIdQueryHandler : ICommandHandler<GetProcessByIdQuery, Process>
    {
        private readonly ICosmosStore<Process> _cosmosStore;

        public GetProcessByIdQueryHandler(ICosmosStore<Process> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }

        public Task<Process> ExecuteAsync(GetProcessByIdQuery command, Process previousResult)
        {
            return _cosmosStore.FindAsync(command.Id);
        }
    }
}
