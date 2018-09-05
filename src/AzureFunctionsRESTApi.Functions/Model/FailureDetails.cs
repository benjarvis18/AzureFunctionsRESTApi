using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionsRESTApi.Functions.Model
{
    public class FailureDetails
    {
        [JsonProperty("errorNumber")]
        public string ErrorNumber { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }
    }
}
