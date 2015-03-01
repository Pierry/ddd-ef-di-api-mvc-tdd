using System.Linq;
using SpaUserControl.Domain.Entities;
using SpaUserControl.Domain.Interfaces.Repositories;

namespace SpaUserControl.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public User Get(string email)
        {
            return Get().FirstOrDefault(c => c.Email.Equals(email));
        }
    }
}