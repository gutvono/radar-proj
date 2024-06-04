using CsvHelper;
using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;

namespace FileGenerator
{
    public class FileWriter
    {
        private MongoReader _mongoReader;
        private SqlReader _sqlReader;
        private List<Radar> _radarList;
        private readonly string BaseFilePath = @"C:\5by5\radar-proj\data";

        public FileWriter(int banco)
        {
            _radarList = new List<Radar>();

            if (banco == 1)
            {
                _sqlReader = new SqlReader();
                _radarList = _sqlReader.GetSqlData();
            }
            else if (banco == 2)
            {
                _mongoReader = new MongoReader();
                _radarList = _mongoReader.GetMongoData();
            }
        }

        public void GenerateCsv()
        {
            string filePath = Path.Combine(BaseFilePath, "radars.csv");
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(_radarList);
            }
            Console.WriteLine($"CSV file generated at {filePath}");
        }

        public void GenerateJson()
        {
            string filePath = Path.Combine(BaseFilePath, "radars.json");
            string json = JsonConvert.SerializeObject(_radarList, Formatting.Indented);
            File.WriteAllText(filePath, json);
            Console.WriteLine($"JSON file generated at {filePath}");
        }

        public void GenerateXml()
        {
            string filePath = Path.Combine(BaseFilePath, "radars.xml");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Radar>));
            using (var writer = new StreamWriter(filePath))
            {
                xmlSerializer.Serialize(writer, _radarList);
            }
            Console.WriteLine($"XML file generated at {filePath}");
        }
    }
}
