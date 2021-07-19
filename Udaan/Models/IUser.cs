using System;
namespace Udaan.Models
{
    public abstract class IUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string MobileNo { get; set; }

        public string PinCode { get; set; }

        public bool IsAdmin { get; set; }

        public CovidProfile Profile { get; set; }

        public virtual bool UpdateCovidResult(IUser user, bool testResult)
        {
            throw new NotSupportedException("Normal User cannot update Covid Result!!");
        }

        public IUser(int userId, string username, string mobileNo, string pinCode, CovidProfile profile, bool isAdmin)
        {
            UserName = username;
            MobileNo = mobileNo;
            PinCode = pinCode;
            Profile = new CovidProfile();
            Profile = profile;
            IsAdmin = isAdmin;
            UserId = userId;
        }

    }
}
