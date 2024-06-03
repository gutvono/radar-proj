using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConfig
{
    public class MongoConfig
    {
        [JsonProperty("Connection")]
        public string Connection { get; set; }

        [JsonProperty("Query")]
        public MongoQueryConfig Query { get; set; }
    }
}
