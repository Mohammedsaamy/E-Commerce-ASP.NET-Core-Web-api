using Context;
using Microsoft.EntityFrameworkCore;
using Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class GenericRepository<T> : IGernaricRepository<T> where T : class
    {
        EcommerceDB Context;
        DbSet<T> dbSet;

        public GenericRepository(EcommerceDB _Context)
        {
            Context = _Context;
            dbSet = Context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public T GetOne(int entity)
        {
            var existingEntity = dbSet.Find(entity);
            if (existingEntity !=null)
            {
               return existingEntity;
            }
            return null;

        }

        public void Create(T entity)
        {
            dbSet.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
            Context.SaveChanges();
        }

        public void Update(T entity, int id)
        {
            var existingEntity = GetOne(id);
            Context.Entry(existingEntity).CurrentValues.SetValues(entity);
            Context.SaveChanges();
        }
    }
}
