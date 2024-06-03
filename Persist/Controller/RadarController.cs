﻿using Model;
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

        public override bool Delete(int id) => _radarService.Delete(id);

        public override Radar Get(int id) => _radarService.Get(id);

        public override List<Radar> GetAll() => _radarService.GetAll();

        public override bool Insert(Radar entity) => _radarService.Insert(entity);

        public override bool InsertMany(List<Radar> entities) => _radarService.InsertMany(entities);

        public override bool Update(Radar entity) => _radarService.Update(entity);
    }
}
