using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConfig
{
    public class MongoQueryConfig
    {
        [JsonProperty("INSERT")]
        public string Insert { get; set; }

        [JsonProperty("INSERTMANY")]
        public string InsertMany { get; set; }

        [JsonProperty("UPDATE")]
        public string Update { get; set; }

        [JsonProperty("DELETE")]
        public string Delete { get; set; }

        [JsonProperty("GET")]
        public string Get { get; set; }

        [JsonProperty("GETALL")]
        public string GetAll { get; set; }
    }
}
