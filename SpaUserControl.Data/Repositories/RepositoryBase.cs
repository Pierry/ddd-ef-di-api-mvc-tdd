using SpaUserControl.Data.Context;
using SpaUserControl.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SpaUserControl.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected AppContext Db;
        
        public TEntity Get(Guid id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return Db.Set<TEntity>().ToList();
        }

        public TEntity Create(TEntity item)
        {
            TEntity adicionado = Db.Set<TEntity>().Add(item);
            Db.SaveChanges();
            return adicionado;
        }

        public void Update(TEntity item)
        {
            Db.Entry(item).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Delete(TEntity item)
        {
            Db.Set<TEntity>().Remove(item);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
