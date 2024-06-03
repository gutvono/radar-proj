using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConfig
{
    public class Config
    {
        [JsonProperty("SQL")]
        public SqlConfig Sql { get; set; }

        [JsonProperty("MONGO")]
        public MongoConfig Mongo { get; set; }
    }
}
