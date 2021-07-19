using System;
using Udaan.Models;

namespace Udaan.Services
{
    public class AdminRegistrationService
    {
        public static Admin Register(int userId, string name, string mobileNo, string pinCode)
        {
            return new Admin(userId, name, mobileNo, pinCode);
        }
    }
}
