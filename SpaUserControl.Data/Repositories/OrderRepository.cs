using SpaUserControl.Domain.Entities;
using SpaUserControl.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaUserControl.Data.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public IEnumerable<Order> GetByUserGuid(Guid id)
        {
            return Get().Where(c => c.OrderGuid == id).ToList();
        }
    }
}
