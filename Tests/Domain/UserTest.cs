using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaUserControl.Domain.Entities;

namespace Tests.Domain
{
    [TestClass]
    public class UserTest
    {
        private readonly User _user;

        public UserTest()
        {
            _user = new User(1, new Guid(), "Pierry Borges", "pieerry@gmail.com");
            SetPassword();
        }
        
        [TestMethod]
        public void SetPassword()
        {
            _user.SetPassword("12121212", "12121212");
        }

        [TestMethod]
        public void ResetPassword()
        {
            var newPassword = _user.ResetPassword();
            if (newPassword.Length < 8) throw new Exception("Invalid Password Reset");
        }

        [TestMethod]
        public void ChangeName()
        {
            _user.ChangeName("João");
        }
    }
}
