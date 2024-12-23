using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLayer.Models;
using ModelsLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.Classes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        ApplicationDbContext db;
        DbSet<T> dbContext;
        public GenericRepository(ApplicationDbContext context)
        {
            db = context;
            dbContext = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return dbContext.ToList();
        }
        public T GetEntity(int id)
        {
            return dbContext.Find(id);
        }
        public bool Add(T entity)
        {
            try
            {
                dbContext.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(T entity)
        {
            try
            {
                db.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                T entity = dbContext.Find(id);
                db.Entry(entity).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(T entity)
        {
            try
            {
                db.Entry(entity).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
