using SpaUserControl.Domain.Entities;
using System;

namespace SpaUserControl.Domain.Interfaces.Repositories
{
    public interface IItemRepository : IRepositoryBase<Item>, IDisposable
    {
    }
}
