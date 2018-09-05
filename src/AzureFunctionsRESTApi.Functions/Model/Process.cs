using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionsRESTApi.Functions.Model
{
    public class Process
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("initiatingResourceName")]
        public string InitiatingResourceName { get; set; }

        [JsonProperty("processName")]
        public string ProcessName { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("failureDetails")]
        public FailureDetails FailureDetails { get; set; }

        [JsonProperty("startDateTime")]
        public DateTime StartDateTime { get; set; }

        [JsonProperty("endDateTime")]
        public DateTime? EndDateTime { get; set; }            
    }
}
