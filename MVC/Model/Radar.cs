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
        public string Concessionaria { get; set; }
        public string AnoDoPnvSnv { get; set; }
        public string Rodovia { get; set; }
        public string Uf { get; set; }
        public string Km_m { get; set; }
        public string Municipio { get; set; }
        public string TipoPista { get; set; }
        public string Sentido { get; set; }
        public DateTime DataDaInativacao { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string VelocidadeLeve { get; set; }

        public Radar() { }

        public override string ToString()
        {
            return $"Id: {Id},\n" +
                $"Concessionaria: {Concessionaria}, \n" +
                $"AnoDoPnvSnv: {AnoDoPnvSnv}, \n" +
                $"Rodovia: {Rodovia}, \n" +
                $"UF: {Uf}, \n" +
                $"Km_m: {Km_m}, \n" +
                $"Municipio: {Municipio}, \n" +
                $"TipoPista: {TipoPista}, \n" +
                $"Sentido: {Sentido}, \n" +
                $"DataDaInativacao: {DataDaInativacao}, \n" +
                $"Latitude: {Latitude}, \n" +
                $"Longitude: {Longitude}, \n" +
                $"VelocidadeLeve: {VelocidadeLeve}";
        }
    }
}
