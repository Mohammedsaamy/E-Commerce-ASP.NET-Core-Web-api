using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contract
{
    public interface IGernaricRepository<T>
    {
        IQueryable<T> GetAll();
        T GetOne(int entity);
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity, int id);
    }
}
