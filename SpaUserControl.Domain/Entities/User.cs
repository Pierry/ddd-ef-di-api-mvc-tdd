using System;
using SpaUserControl.Common.Resources;
using SpaUserControl.Common.Validation;

namespace SpaUserControl.Domain.Entities
{
    public class User
    {
        protected User(){}

        public User(string name, string email)
        {
            IdGuid = new Guid();
            Name = name;
            Email = email;
        }

        public int Id { get; set; }
        public Guid IdGuid { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public void SetPassword(string password, string confirmPassword)
        {
            AssertionConcern.AssertArgumentNotNull(password, Notifications.InvalidPassword);
            AssertionConcern.AssertArgumentNotNull(confirmPassword, Notifications.PasswordConfirmation);
            AssertionConcern.AssertArgumentEquals(password, confirmPassword, Notifications.PasswordDoNotMatch);
            AssertionConcern.AssertArgumentLength(password, 6, 20, Notifications.InvalidPassword);

            Password = PasswordAssertionConcern.Encrypt(password);
        }

        public string ResetPassword()
        {
            string password = Guid.NewGuid().ToString().Substring(0, 8);
            Password = PasswordAssertionConcern.Encrypt(password);

            return password;
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentLength(Name, 3, 250, Notifications.InvalidName);
            EmailAssertionConcern.AssertIsValid(Email);
            PasswordAssertionConcern.AssertIsValid(Password);
        }
    }
}