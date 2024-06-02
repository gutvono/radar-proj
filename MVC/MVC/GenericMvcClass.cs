using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace MVC
{
    public abstract class GenericMvcClass<T> : IMvcClass<T>
    {
        public abstract bool Delete(int id);

        public abstract T Get(int id);

        public abstract List<T> GetAll();

        public abstract bool Insert(T entity);

        public abstract bool InsertMany(List<T> entities);

        public abstract bool Update(T entity);
    }
}
