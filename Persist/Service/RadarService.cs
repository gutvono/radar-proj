using Model;
using MVC;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RadarService : GenericMvcClass<Radar>
    {
        private readonly RadarRepository _repository;

        public RadarService() { _repository = new(); }

        public override bool Delete(int id) => _repository.Delete(id);

        public override Radar Get(int id) => _repository.Get(id);

        public override List<Radar> GetAll() => _repository.GetAll();

        public override bool Insert(Radar entity) => _repository.Insert(entity);

        public override bool InsertMany(List<Radar> entities) => _repository.InsertMany(entities);

        public override bool Update(Radar entity) => _repository.Update(entity);
    }
}
