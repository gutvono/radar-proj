using Model;
using MVC;
using RadarRepository;
using RAPRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAPService
{
    public class RAPServiceClass : GenericMvcClass<Radar>
    {
        RAPRepositoryClass _RAPrepository = new();
        RadarRepositoryClass _RadarRepository = new();

        public override bool Delete(int id) => _RAPrepository.Delete(id);

        public override Radar Get(int id) => _RAPrepository.Get(id);

        public override List<Radar> GetAll() => _RAPrepository.GetAll();

        public override bool Insert(Radar entity) => _RAPrepository.Insert(entity);

        public override bool InsertMany(List<Radar> entities) => _RAPrepository.InsertMany(entities);

        public override bool Update(Radar entity) => _RAPrepository.Update(entity);
    }
}
