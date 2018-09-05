using AzureFromTheTrenches.Commanding.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionsRESTApi.Functions.Commands
{
    public class MarkProcessAsSuccessfulCommand : ICommand
    {
        public string Id { get; set; }

        public DateTime EndDateTime { get; set; }
    }
}
