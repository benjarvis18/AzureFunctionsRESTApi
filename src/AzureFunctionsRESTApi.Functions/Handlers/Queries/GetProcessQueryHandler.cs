using AzureFromTheTrenches.Commanding.Abstractions;
using AzureFunctionsRESTApi.Functions.Lookup;
using AzureFunctionsRESTApi.Functions.Model;
using AzureFunctionsRESTApi.Functions.Queries;
using Cosmonaut;
using Cosmonaut.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsRESTApi.Functions.Handlers.Queries
{
    public class GetProcessQueryHandler : ICommandHandler<GetProcessQuery, IEnumerable<Process>>
    {
        private readonly ICosmosStore<Process> _cosmosStore;

        public GetProcessQueryHandler(ICosmosStore<Process> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }

        public async Task<IEnumerable<Process>> ExecuteAsync(GetProcessQuery command, IEnumerable<Process> previousResult)
        {
            return await _cosmosStore
                .Query()
                .Where(p => p.Status == command.Status)
                .ToListAsync();
        }
    }
}
