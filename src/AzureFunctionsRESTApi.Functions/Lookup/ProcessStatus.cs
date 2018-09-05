using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionsRESTApi.Functions.Lookup
{
    public static class ProcessStatus
    {
        public static readonly string InProgress = "in-progress";

        public static readonly string Succeeded = "succeeded";

        public static readonly string Failed = "failed";
    }
}
