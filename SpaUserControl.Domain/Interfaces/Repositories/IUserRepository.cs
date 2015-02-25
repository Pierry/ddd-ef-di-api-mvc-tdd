using System;
using SpaUserControl.Domain.Entities;

namespace SpaUserControl.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IDisposable
    {
        User Get(string email);
        User Get(Guid id);
        void Create(User user);
        void Update(User user);
        void Delete(User user);
    }
}