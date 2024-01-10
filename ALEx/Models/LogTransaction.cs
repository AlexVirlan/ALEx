using Newtonsoft.Json;
using System.Collections.Generic;

namespace ALEx.Models
{
    class LogTransaction
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("protocol")]
        public string Protocol { get; set; }

        [JsonProperty("protocolSrc")]
        public string ProtocolSrc { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("serviceContexts")]
        public List<ServiceContext> ServiceContexts { get; set; }

        [JsonProperty("customMsgAtts")]
        public CustomMsgAtts CustomMsgAtts { get; set; }

        [JsonProperty("correlationId")]
        public string CorrelationId { get; set; }

        [JsonProperty("legs")]
        public List<Leg> Legs { get; set; }
    }

    public partial class CustomMsgAtts
    {
        [JsonProperty("requestLog")]
        public dynamic RequestLog { get; set; }

        [JsonProperty("responseLog")]
        public dynamic ResponseLog { get; set; }

        [JsonProperty("data.tppId")]
        public string DataTppId { get; set; }
    }

    public partial class Leg
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("statustext")]
        public string Statustext { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("vhost")]
        public object Vhost { get; set; }

        [JsonProperty("wafStatus")]
        public long WafStatus { get; set; }

        [JsonProperty("bytesSent")]
        public long BytesSent { get; set; }

        [JsonProperty("bytesReceived")]
        public long BytesReceived { get; set; }

        [JsonProperty("remoteName")]
        public string RemoteName { get; set; }

        [JsonProperty("remoteAddr")]
        public string RemoteAddr { get; set; }

        [JsonProperty("localAddr")]
        public string LocalAddr { get; set; }

        [JsonProperty("remotePort")]
        public string RemotePort { get; set; }

        [JsonProperty("localPort")]
        public string LocalPort { get; set; }

        [JsonProperty("sslsubject")]
        public string Sslsubject { get; set; }

        [JsonProperty("leg")]
        public long LegLeg { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("serviceName")]
        public string ServiceName { get; set; }

        [JsonProperty("subject")]
        public object Subject { get; set; }

        [JsonProperty("operation")]
        public string Operation { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("finalStatus")]
        public string FinalStatus { get; set; }
    }

    public partial class ServiceContext
    {
        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("monitor")]
        public bool Monitor { get; set; }

        [JsonProperty("client")]
        public object Client { get; set; }

        [JsonProperty("org")]
        public object Org { get; set; }

        [JsonProperty("app")]
        public object App { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }
    }
}
