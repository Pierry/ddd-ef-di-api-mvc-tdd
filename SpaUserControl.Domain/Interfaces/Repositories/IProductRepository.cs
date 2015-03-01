using SpaUserControl.Domain.Entities;
using System;

namespace SpaUserControl.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>, IDisposable
    {

    }
}
