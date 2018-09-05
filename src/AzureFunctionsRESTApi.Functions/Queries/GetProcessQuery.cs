using AzureFromTheTrenches.Commanding.Abstractions;
using AzureFunctionsRESTApi.Functions.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionsRESTApi.Functions.Queries
{
    public class GetProcessQuery : ICommand<IEnumerable<Process>>
    {
        public string Status { get; set; }
    }
}
