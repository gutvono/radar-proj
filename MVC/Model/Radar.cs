using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Radar
    {
        public int? Id { get; set; }

        [JsonProperty("concessionaria")]
        public string Concessionaria { get; set; }

        [JsonProperty("ano_do_pnv_snv")]
        public string AnoDoPnvSnv { get; set; }

        [JsonProperty("tipo_de_radar")]
        public string TipoDeRadar {  get; set; }

        [JsonProperty("rodovia")]
        public string Rodovia { get; set; }

        [JsonProperty("uf")]
        public string Uf { get; set; }

        [JsonProperty("km_m")]
        public string Km_m { get; set; }

        [JsonProperty("municipio")]
        public string Municipio { get; set; }

        [JsonProperty("tipo_pista")]
        public string TipoPista { get; set; }

        [JsonProperty("sentido")]
        public string Sentido { get; set; }

        [JsonProperty("situacao")]
        public string Situacao { get; set; }

        public DateTime? DataDaInativacao { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("velocidade_leve")]
        public string VelocidadeLeve { get; set; }

        [JsonProperty("data_da_inativacao")]
        private List<DateTime> DataDaInativacaoArray
        {
            set
            {
                if (value != null) foreach (var item in value) DataDaInativacao = item.Year == 0001 ? null : item;
                else DataDaInativacao = null;
            }
        }

        public Radar() { }

        public override string ToString()
        {
            return $"Id: {Id},\n" +
                $"Concessionaria: {Concessionaria}, \n" +
                $"AnoDoPnvSnv: {AnoDoPnvSnv}, \n" +
                $"TipoDeRadar: {TipoDeRadar}" +
                $"Rodovia: {Rodovia}, \n" +
                $"UF: {Uf}, \n" +
                $"Km_m: {Km_m}, \n" +
                $"Municipio: {Municipio}, \n" +
                $"TipoPista: {TipoPista}, \n" +
                $"Sentido: {Sentido}, \n" +
                $"Situacao: {Situacao}" +
                $"DataDaInativacao: {DataDaInativacao}, \n" +
                $"Latitude: {Latitude}, \n" +
                $"Longitude: {Longitude}, \n" +
                $"VelocidadeLeve: {VelocidadeLeve}";
        }
    }
}
