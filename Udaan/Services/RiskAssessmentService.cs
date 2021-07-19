using System;
using System.Collections.Generic;
using System.Linq;
using Udaan.Models;

namespace Udaan.Services
{
    public class RiskAssessmentService
    {
        public static int AssessRiskProfile(IUser user)
        {
            if(!user.Profile.Symptoms.Any() && !user.Profile.TravelHistory && !user.Profile.ContactWithCovidPositivePatient)
            {
                return 5;
            }

            if(user.Profile.Symptoms.Count() == 1 && (user.Profile.TravelHistory || user.Profile.ContactWithCovidPositivePatient))
            {
                return 50;
            }

            if(user.Profile.Symptoms.Count() == 2 && (user.Profile.TravelHistory || user.Profile.ContactWithCovidPositivePatient))
            {
                return 75;
            }

            if(user.Profile.Symptoms.Count() > 2 && (user.Profile.TravelHistory || user.Profile.ContactWithCovidPositivePatient))
            {
                return 95;
            }

            if(user.Profile.Symptoms.Any() && !user.Profile.TravelHistory && !user.Profile.ContactWithCovidPositivePatient)
            {
                return 10;
            }
            return 0;
        }

        public static void BuildAssessmentProfile(IUser user, List<string> symptoms, bool travelHistory, bool contactWithCovidPatient)
        {
            if (user.Profile == null)
            {
                user.Profile = new CovidProfile();
            }

            user.Profile.Symptoms = new List<string>();
            user.Profile.Symptoms.AddRange(symptoms);
            user.Profile.TravelHistory = travelHistory;
            user.Profile.ContactWithCovidPositivePatient = contactWithCovidPatient;
        }
    }
}
