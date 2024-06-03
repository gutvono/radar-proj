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
    internal class RAPRepository : GenericMvcClass<Radar>
    {
        private readonly MongoClient MongoConnection;
        private readonly Config _config;
        private IMongoDatabase _database; 
        private IMongoCollection<BsonDocument> _collection;

        public RAPRepository()
        {
            MongoConnection = new MongoClient(_config.Mongo.Connection);
            _database = MongoConnection.GetDatabase("RadarDB");
            _collection = _database.GetCollection<BsonDocument>("Radar");
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Radar Get(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Radar> GetAll()
        {
            throw new NotImplementedException();
        }

        public override bool Insert(Radar entity)
        {
            throw new NotImplementedException();
        }

        public override bool InsertMany(List<Radar> entities)
        {
            bool result = false;
            List<BsonDocument> ListaBson = new();

            foreach (Radar entity in entities)
            {
                ListaBson.Add(new BsonDocument
                {
                    { "concessionaria", entity.Concessionaria },
                    { "ano_do_pnv_snv", entity.AnoDoPnvSnv },
                    { "rodovia", entity.Rodovia },
                    { "uf", entity.Uf },
                    { "km_m", entity.Km_m },
                    { "municipio", entity.Municipio },
                    { "tipo_pista", entity.TipoPista },
                    { "sentido", entity.Sentido }
                });
            }

            return result;
        }

        public override bool Update(Radar entity)
        {
            throw new NotImplementedException();
        }
    }
}
