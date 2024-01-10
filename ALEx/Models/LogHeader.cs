using Newtonsoft.Json;

namespace ALEx.Models
{
    class LogHeader
    {
        [JsonProperty("logCreationTime")]
        public string LogCreationTime { get; set; }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("domainId")]
        public string DomainId { get; set; }

        [JsonProperty("groupId")]
        public string GroupId { get; set; }

        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        [JsonProperty("serviceId")]
        public string ServiceId { get; set; }

        [JsonProperty("serviceName")]
        public string ServiceName { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
