using SpaUserControl.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SpaUserControl.Domain.Interfaces.Repositories
{
    public interface IOrderRepository : IRepositoryBase<Order>, IDisposable
    {
        IEnumerable<Order> GetByUserGuid(Guid id);
    }
}
