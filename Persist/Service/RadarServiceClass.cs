using Model;
using MVC;
using RadarRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RadarServiceClass : GenericMvcClass<Radar>
    {
        private readonly RadarRepositoryClass _repository;

        public RadarServiceClass() { _repository = new(); }

        public override bool Delete(int id) => _repository.Delete(id);

        public override Radar Get(int id) => _repository.Get(id);

        public override List<Radar> GetAll() => _repository.GetAll();

        public override bool Insert(Radar entity) => _repository.Insert(entity);

        public override bool InsertMany(List<Radar> entities) => _repository.InsertMany(entities);

        public override bool Update(Radar entity) => _repository.Update(entity);
    }
}
