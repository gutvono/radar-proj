using Model;
using RadarRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGenerator
{
    public class SqlReader
    {
        RadarRepositoryClass _SqlRepository;

        public SqlReader() => _SqlRepository = new();

        public List<Radar> GetSqlData()
        {
            return _SqlRepository.GetAll();
        }
    }
}
