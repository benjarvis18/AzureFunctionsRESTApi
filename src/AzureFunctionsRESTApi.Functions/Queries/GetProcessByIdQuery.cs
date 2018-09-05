using AzureFromTheTrenches.Commanding.Abstractions;
using AzureFunctionsRESTApi.Functions.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionsRESTApi.Functions.Queries
{
    public class GetProcessByIdQuery : ICommand<Process>
    {
        public string Id { get; set; }
    }
}
