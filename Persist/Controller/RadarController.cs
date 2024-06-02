using Model;
using MVC;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class RadarController : GenericMvcClass<Radar>
    {
        private readonly RadarService _radarService;

        public RadarController () { _radarService = new(); }

        public override bool Delete(int id)
        {
            return _radarService.Delete(id);
        }

        public override Radar Get(int id)
        {
            return _radarService.Get(id);
        }

        public override List<Radar> GetAll()
        {
            return _radarService.GetAll();
        }

        public override bool Insert(Radar entity)
        {
            return _radarService.Insert(entity);
        }

        public override bool InsertMany(List<Radar> entities)
        {
            return _radarService.InsertMany(entities);
        }

        public override bool Update(Radar entity)
        {
            return _radarService.Update(entity);
        }
    }
}
