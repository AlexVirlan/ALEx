using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace ALEx.Models
{
    class AxwayLog
    {
        public LogHeader LogHeader { get; set; }
        public int NumberOfTransactions { get; set; } = 0;
        public List<JObject> LogTransactions { get; set; }

        public AxwayLog()
        {
            LogTransactions = new List<JObject>();
        }
    }
}
