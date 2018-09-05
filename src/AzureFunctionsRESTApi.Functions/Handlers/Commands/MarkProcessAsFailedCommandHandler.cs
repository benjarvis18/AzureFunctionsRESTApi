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
    public class MarkProcessAsFailedCommandHandler : ICommandHandler<MarkProcessAsFailedCommand>
    {
        private readonly ICosmosStore<Process> _cosmosStore;

        public MarkProcessAsFailedCommandHandler(ICosmosStore<Process> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }

        public async Task ExecuteAsync(MarkProcessAsFailedCommand command)
        {
            var process = await _cosmosStore.FindAsync(command.Id);

            process.EndDateTime = command.EndDateTime;
            process.Status = ProcessStatus.Failed;
            process.FailureDetails = new FailureDetails()
            {
                ErrorNumber = command.ErrorNumber,
                ErrorMessage = command.ErrorMessage
            };

            await _cosmosStore.UpdateAsync(process);
        }
    }
}
