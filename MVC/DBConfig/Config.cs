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
        public SqlConfig Sql { get; }
        [JsonProperty("MONGO")]
        public string Mongo { get; }
    }
}
