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
    public class CreateProcessCommandHandler : ICommandHandler<CreateProcessCommand>
    {
        private readonly ICosmosStore<Process> _cosmosStore;

        public CreateProcessCommandHandler(ICosmosStore<Process> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }

        public async Task ExecuteAsync(CreateProcessCommand command)
        {
            var process = new Process()
            {
                Id = command.ProcessId,
                ProcessName = command.ProcessName,
                InitiatingResourceName = command.InitiatingResourceName,
                StartDateTime = command.StartDateTime,
                Status = ProcessStatus.InProgress
            };

            await _cosmosStore.AddAsync(process);
        }
    }
}
