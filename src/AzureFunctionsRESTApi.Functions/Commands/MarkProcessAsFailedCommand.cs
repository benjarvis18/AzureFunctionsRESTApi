using AzureFromTheTrenches.Commanding.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionsRESTApi.Functions.Commands
{
    public class MarkProcessAsFailedCommand : ICommand
    {
        public string Id { get; set; }

        public DateTime EndDateTime { get; set; }

        public int ErrorNumber { get; set; }

        public string ErrorMessage { get; set; }
    }
}
