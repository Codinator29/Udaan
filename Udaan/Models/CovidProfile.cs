using System;
using System.Collections.Generic;

namespace Udaan.Models
{
    public class CovidProfile
    {
        public List<string> Symptoms { get; set; }

        public bool TravelHistory { get; set; } = false;

        public bool ContactWithCovidPositivePatient { get; set; } = false;

        public bool CovidTest { get; set; } = false;

        public CovidProfile()
        {
            Symptoms = new List<string>();
        }
    }
}
