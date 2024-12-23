using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IGenericRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll();
        T GetEntity(int id);
        bool Add(T entity);
        bool Delete(int id);
        bool Delete(T entity);
        bool Update(T entity);
        void Save();
    }
}
