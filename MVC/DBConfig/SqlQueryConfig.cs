using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConfig
{
    public class SqlQueryConfig
    {
        [JsonProperty("INSERT")]
        public string Insert { get; }

        [JsonProperty("INSERTMANY")]
        public string InsertMany { get; }

        [JsonProperty("UPDATE")]
        public string Update { get; }

        [JsonProperty("DELETE")]
        public string Delete { get; }

        [JsonProperty("GET")]
        public string Get { get; }

        [JsonProperty("GETALL")]
        public string GetAll { get; }
    }
}
