using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConfig
{
    public class SqlConfig
    {
        [JsonProperty("Connection")]
        public string ConnectionString { get; }

        [JsonProperty("Query")]
        public SqlQueryConfig Query { get; }
    }
}
