using System;
using SpaUserControl.Common.Resources;
using SpaUserControl.Common.Validation;

namespace SpaUserControl.Domain.Entities
{
    public class User
    {
        public int UserId { get; private set; }
        public Guid UserIdGuid { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        protected User() { }

        public User(string name, string email)
        {
            UserIdGuid = new Guid();
            Name = name;
            Email = email;

            Validate();
        }

        public User(int userId, Guid userIdGuid, string name, string email)
        {
            UserId = userId;
            UserIdGuid = userIdGuid;
            Name = name;
            Email = email;
        }

        public void SetPassword(string password, string confirmPassword)
        {
            AssertionConcern.AssertArgumentNotNull(password, Notifications.InvalidPassword);
            AssertionConcern.AssertArgumentNotNull(confirmPassword, Notifications.PasswordConfirmation);
            AssertionConcern.AssertArgumentEquals(password, confirmPassword, Notifications.PasswordDoNotMatch);
            AssertionConcern.AssertArgumentLength(password, 6, 20, Notifications.InvalidPassword);

            Password = PasswordAssertionConcern.Encrypt(password);

            Validate();
        }

        public string ResetPassword()
        {
            var password = Guid.NewGuid().ToString().Substring(0, 8);
            Password = PasswordAssertionConcern.Encrypt(password);

            Validate();
            return password;
        }

        public void ChangeName(string name)
        {
            Name = name;

            Validate();
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentLength(Name, 3, 250, Notifications.InvalidName);
            EmailAssertionConcern.AssertIsValid(Email);
            PasswordAssertionConcern.AssertIsValid(Password);
        }
    }
}