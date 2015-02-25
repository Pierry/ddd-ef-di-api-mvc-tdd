using System;
using SpaUserControl.Domain.Entities;

namespace SpaUserControl.Domain.Interfaces.Services
{
    public interface IUserService : IDisposable
    {
        User Authenticate(string email, string password);
        User GetByEmail(string email);
        void Register(string name, string email, string password, string confirmPassword);
        void ChangeInformation(string name, string email);
        void ChangePassword(string email, string password, string newPassword, string confirmNewPassword);
        string ResetPassword(string email);
    }
}