using AzureFromTheTrenches.Commanding.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionsRESTApi.Functions.Commands
{
    public class CreateProcessCommand : ICommand
    {
        public string ProcessId { get; set; }

        public string InitiatingResourceName { get; set; }

        public string ProcessName { get; set; }

        public DateTime StartDateTime { get; set; }
    }
}
