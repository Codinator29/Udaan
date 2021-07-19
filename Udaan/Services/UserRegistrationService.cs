using System;
using Udaan.Models;

namespace Udaan.Services
{
    public class UserRegistrationService
    {
        public static User Register(int userId, string name, string mobileNo, string pinCode)
        {
            return new User(userId, name, mobileNo, pinCode);
        }
    }
}
