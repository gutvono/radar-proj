using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace MVC
{
    public interface IMvcClass<T>
    {
        public bool Insert(T entity);
        public bool InsertMany (List<T> entities);
        public bool Update(T entity);
        public bool Delete(int id);
        T Get(int id);
        public List<T> GetAll();
    }
}
