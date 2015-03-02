using SpaUserControl.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SpaUserControl.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> Get(int page);
        Order GetByGuid(Guid id);
        IEnumerable<Order> GetByUserGuid(Guid id);
        void Create(User user, Item item);
        void AddItem(Guid id, Item item);
        void Delete(Guid id);
        void Dispose();
    }
}
