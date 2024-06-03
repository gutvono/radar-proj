using Model;
using MVC;
using RAPService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAPController
{
    public class RAPControllerClass : GenericMvcClass<Radar>
    {
        RAPServiceClass _service = new();

        public override bool Delete(int id) => _service.Delete(id);

        public override Radar Get(int id) => _service.Get(id);

        public override List<Radar> GetAll() => _service.GetAll();

        public override bool Insert(Radar entity) => _service.Insert(entity);

        public override bool InsertMany(List<Radar> entities) => _service.InsertMany(entities);

        public override bool Update(Radar entity) => _service.Update(entity);
    }
}
