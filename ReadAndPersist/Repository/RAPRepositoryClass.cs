using DBConfig;
using Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAPRepository
{
    public class RAPRepositoryClass : GenericMvcClass<Radar>
    {
        private MongoClient MongoConnection;
        private Config _config = JsonLoader.LoadConfig(@"C:\5by5\radar-proj\MVC\DBConfig\query.json");
        private IMongoDatabase _database;
        private IMongoCollection<BsonDocument> _collection;

        public RAPRepositoryClass()
        {
            try
            {
                MongoConnection = new MongoClient(_config.Mongo.Connection);
                _database = MongoConnection.GetDatabase("RadarDB");
                _collection = _database.GetCollection<BsonDocument>("Radar");
            }
            catch (Exception e)
            {
                Console.WriteLine("-- ERRO ao carregar configuração ou conectar ao MongoDB...\n" +
                    $"{e.Message}");
            }
        }

        public override bool Delete(int id) => throw new NotImplementedException();

        public override Radar Get(int id) => throw new NotImplementedException();

        public override List<Radar> GetAll()
        {
            List<Radar> RadarList = new List<Radar>();

            try
            {
                var documents = _collection.Find(new BsonDocument()).ToList();

                foreach (var doc in documents)
                {
                    Radar radar = new Radar
                    {
                        Id = doc.GetValue("id").AsInt32,
                        Concessionaria = doc.GetValue("concessionaria").AsString,
                        AnoDoPnvSnv = doc.GetValue("ano_do_pnv_snv").AsString,
                        TipoDeRadar = doc.GetValue("tipo_de_radar").AsString,
                        Rodovia = doc.GetValue("rodovia").AsString,
                        Uf = doc.GetValue("uf").AsString,
                        Km_m = doc.GetValue("km_m").AsString,
                        Municipio = doc.GetValue("municipio").AsString,
                        TipoPista = doc.GetValue("tipo_pista").AsString,
                        Sentido = doc.GetValue("sentido").AsString,
                        Situacao = doc.GetValue("situacao").AsString,
                        DataDaInativacao = doc.Contains("data_da_inativacao") && doc["data_da_inativacao"].IsBsonNull ? null : (DateTime?)doc.GetValue("data_da_inativacao").ToUniversalTime(),
                        Latitude = doc.GetValue("latitude").AsString,
                        Longitude = doc.GetValue("longitude").AsString,
                        VelocidadeLeve = doc.GetValue("velocidade_leve").AsString
                    };

                    RadarList.Add(radar);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("-- ERRO ao obter todos os registros...\n" +
                    $"{e.Message}");
            }

            return RadarList;
        }


        public override bool Insert(Radar entity) => throw new NotImplementedException();

        public override bool InsertMany(List<Radar> entities)
        {
            bool result = false;
            List<BsonDocument> ListaBson = new();

            try
            {
                foreach (Radar entity in entities)
                {
                    var filter = Builders<BsonDocument>.Filter.Eq("id", entity.Id);
                    var existingDocument = _collection.Find(filter).FirstOrDefault();

                    if (existingDocument == null)
                    {
                        ListaBson.Add(new BsonDocument
                        {
                            { "id", entity.Id },
                            { "concessionaria", entity.Concessionaria },
                            { "ano_do_pnv_snv", entity.AnoDoPnvSnv },
                            { "tipo_de_radar", entity.TipoDeRadar },
                            { "rodovia", entity.Rodovia },
                            { "uf", entity.Uf },
                            { "km_m", entity.Km_m },
                            { "municipio", entity.Municipio },
                            { "tipo_pista", entity.TipoPista },
                            { "sentido", entity.Sentido },
                            { "situacao", entity.Situacao },
                            { "data_da_inativacao", entity.DataDaInativacao },
                            { "latitude", entity.Latitude },
                            { "longitude", entity.Longitude },
                            { "velocidade_leve", entity.VelocidadeLeve }
                        });
                    }
                }

                if (ListaBson.Count > 0)
                {
                    Console.WriteLine($"Estão sendo inseridos {ListaBson.Count} elementos no MongoDB...");
                    _collection.InsertMany(ListaBson);
                    result = true;
                }
                else Console.WriteLine("Não há novos elementos para inserir no MongoDB.");
            }
            catch (Exception e)
            {
                Console.WriteLine("-- ERRO ao inserir muitos registros...\n" +
                    $"{e.Message}");
                result = false;
            }

            return result;
        }

        public override bool Update(Radar entity) => throw new NotImplementedException();
    }
}
