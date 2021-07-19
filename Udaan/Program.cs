using System;
using System.Collections.Generic;
using System.Linq;
using Udaan.Models;
using Udaan.Services;

namespace Udaan
{
    class Program
    {
        static void Main(string[] args)
        {
            int Id = 1;
            List<IUser> users = new List<IUser>();
           

            // User Registration
            var user = UserRegistrationService.Register(Id++, "John", "884", "111111");
            users.Add(user);
            Console.WriteLine("UserId:" + user.UserId);

            var user2 = UserRegistrationService.Register(Id++, "Jill", "887", "111111");
            users.Add(user2);
            Console.WriteLine("UserId:" + user2.UserId);

            // Admin Registration
            var admin1 = AdminRegistrationService.Register(Id++, "Admin", "447", "123444");
            users.Add(admin1);
            Console.WriteLine("AdminId:" + admin1.UserId);

            // Build Risk Assessment Profile and Assess Risk
            RiskAssessmentService.BuildAssessmentProfile(user, new List<string> { "cold", "fever" }, false, false);
            var riskPercent = RiskAssessmentService.AssessRiskProfile(user);

            Console.WriteLine($"RiskPercent for userId {user.UserId} is {riskPercent}");

            // Update Covid Result
            Console.WriteLine($"Covid Result for userId {user.UserId} is {user.Profile?.CovidTest}");
            admin1.UpdateCovidResult(user, true);
            Console.WriteLine($"Covid Result for userId {user.UserId} is {user.Profile?.CovidTest}");

            // Get ZoneInfo
            ZoneUpdationService.UpdateZones(users);
            var zoneInfo = ZoneUpdationService.GetZoneInfo(user.PinCode);
            if(zoneInfo.Any())
                Console.WriteLine($"Zone patient count {zoneInfo[0]} and Zone Status {zoneInfo[1]}");
            else
                Console.WriteLine($"No Data found for the given pincode");

            Console.ReadLine();
        }
    }
}
