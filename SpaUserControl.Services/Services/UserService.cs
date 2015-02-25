using System;
using SpaUserControl.Common.Resources;
using SpaUserControl.Common.Validation;
using SpaUserControl.Domain.Entities;
using SpaUserControl.Domain.Interfaces.Repositories;
using SpaUserControl.Domain.Interfaces.Services;

namespace SpaUserControl.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Authenticate(string email, string password)
        {
            User user = GetByEmail(email);
            if (user.Password != PasswordAssertionConcern.Encrypt(password))
                throw new Exception(Notifications.InvalidCredentials);
            return user;
        }

        public User GetByEmail(string email)
        {
            User user = _userRepository.Get(email);
            if (user == null) throw new Exception(Notifications.UserNotFound);

            return user;
        }

        public void Register(string name, string email, string password, string confirmPassword)
        {
            var user = new User(name, email);
            user.SetPassword(password, confirmPassword);
            user.Validate();

            _userRepository.Create(user);
        }

        public void ChangeInformation(string name, string email)
        {
            User user = GetByEmail(email);

            user.ChangeName(name);
            user.Validate();

            _userRepository.Update(user);
        }

        public void ChangePassword(string email, string password, string newPassword, string confirmNewPassword)
        {
            User user = Authenticate(email, password);

            user.SetPassword(newPassword, confirmNewPassword);
            user.Validate();

            _userRepository.Update(user);
        }

        public string ResetPassword(string email)
        {
            User user = GetByEmail(email);
            string password = user.ResetPassword();
            user.Validate();

            _userRepository.Update(user);
            return password;
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }
    }
}