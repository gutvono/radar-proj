using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConfig
{
    public static class JsonLoader
    {
        public static Config LoadConfig(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException($"Arquivo de configuração não encontrado: {path}");

            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Config>(json);
        }
    }
}
