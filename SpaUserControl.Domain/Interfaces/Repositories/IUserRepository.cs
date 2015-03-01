using System;
using SpaUserControl.Domain.Entities;

namespace SpaUserControl.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>, IDisposable
    {
        User Get(string email);        
    }
}