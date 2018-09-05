using AzureFromTheTrenches.Commanding.Abstractions;
using AzureFunctionsRESTApi.Functions.Commands;
using AzureFunctionsRESTApi.Functions.Lookup;
using AzureFunctionsRESTApi.Functions.Model;
using Cosmonaut;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsRESTApi.Functions.Handlers.Commands
{
    public class MarkProcessAsSuccessfulCommandHandler : ICommandHandler<MarkProcessAsSuccessfulCommand>
    {
        private readonly ICosmosStore<Process> _cosmosStore;

        public MarkProcessAsSuccessfulCommandHandler(ICosmosStore<Process> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }

        public async Task ExecuteAsync(MarkProcessAsSuccessfulCommand command)
        {
            var process = await _cosmosStore.FindAsync(command.Id);
            process.EndDateTime = command.EndDateTime;
            process.Status = ProcessStatus.Succeeded;

            await _cosmosStore.UpdateAsync(process);
        }
    }
}
