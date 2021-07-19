using System;
namespace Udaan.Models
{
    public class User : IUser
    { 
        public User(int userId, string username, string mobileNumber, string pinCode, CovidProfile profile = null): base(userId, username, mobileNumber, pinCode, profile, false)
        {
        }
    }
}
