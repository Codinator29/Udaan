using System;
namespace Udaan.Models
{
    public class Admin: IUser
    {
        public Admin(int userId, string userName, string mobileNo, string pinCode, CovidProfile profile = null): base(userId, userName, mobileNo, pinCode, profile, true)
        {
        }

        public override bool UpdateCovidResult(IUser user, bool testResult)
        {
            if(user.Profile == null)
            {
                user.Profile = new CovidProfile();
            }
            user.Profile.CovidTest = testResult;
            return true;
        }
    }
}
