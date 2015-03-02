using System;
using System.Collections.Generic;

namespace SpaUserControl.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity Get(Guid id);
        TEntity Create(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
    }
}
