using SpaUserControl.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SpaUserControl.Domain.Interfaces.Services
{
    public interface IItemService 
    {
        IEnumerable<Item> Get(int page);
        Item GetByGuid(Guid id);
        void ChangeAmont(Guid id, int newAmont);
        void Create(Product product, Order order, int amont);
        void Delete(Guid id);
        void Dispose();

    }
}
