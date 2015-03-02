using SpaUserControl.Domain.Interfaces.Repositories;
using SpaUserControl.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace SpaUserControl.Services.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public IEnumerable<TEntity> Get()
        {
            return _repositoryBase.Get();
        }

        public TEntity Get(Guid id)
        {
            return _repositoryBase.Get(id);
        }

        public TEntity Create(TEntity item)
        {
            return _repositoryBase.Create(item);
        }

        public void Update(TEntity item)
        {
            _repositoryBase.Update(item);
        }

        public void Delete(TEntity item)
        {
            _repositoryBase.Delete(item);
        }
    }
}
