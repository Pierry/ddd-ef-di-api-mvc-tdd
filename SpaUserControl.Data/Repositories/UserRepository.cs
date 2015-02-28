using System;
using System.Data.Entity;
using System.Linq;
using SpaUserControl.Data.Context;
using SpaUserControl.Domain.Entities;
using SpaUserControl.Domain.Interfaces.Repositories;

namespace SpaUserControl.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppContext _context = new AppContext();
        
        public User Get(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email.ToLower().Equals(email));
        }

        public User Get(Guid id)
        {
            return _context.Users.FirstOrDefault(x => x.UserIdGuid == id);
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}