using Model;
using RAPRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGenerator
{
    public class MongoReader
    {
        RAPRepositoryClass _MongoRepository;

        public MongoReader() => _MongoRepository = new();

        public List<Radar> GetMongoData()
        {
            return _MongoRepository.GetAll();
        }
    }
}
