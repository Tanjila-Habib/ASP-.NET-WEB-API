using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T>
    {
        bool Create(T obj);
        T Get(int id);
        List<T> Get();
        bool Update(T obj);
        bool Delete(int id);
    }
}
