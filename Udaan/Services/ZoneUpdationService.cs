using System;
using System.Collections.Generic;
using Udaan.Models;

namespace Udaan.Services
{
    public class ZoneUpdationService
    {
        static Dictionary<string, ZoneEnums> pinCodeDictionary = new Dictionary<string, ZoneEnums>();
        static Dictionary<string, int> pincodeMap = new Dictionary<string, int>();

        public static void UpdateZones(List<IUser> users)
        { 
            foreach(var user in users)
            {
                if(!pincodeMap.ContainsKey(user.PinCode))
                {
                    pincodeMap.Add(user.PinCode, 0);
                }

                if(user.Profile?.CovidTest ?? false)
                {
                    pincodeMap[user.PinCode]++;
                }
            }

            foreach(var pinCode in pincodeMap)
            {
                if(!pinCodeDictionary.ContainsKey(pinCode.Key))
                {
                    pinCodeDictionary.Add(pinCode.Key, ZoneEnums.Green);
                }
            }

            foreach(var pinCode in pincodeMap.Keys)
            {
                if (pincodeMap[pinCode] > 5)
                {
                    pinCodeDictionary[pinCode] = ZoneEnums.Red;
                }

                else if (pincodeMap[pinCode] <= 5 && pincodeMap[pinCode] > 0)
                {
                    pinCodeDictionary[pinCode] = ZoneEnums.Orange;
                }
                else
                {
                    pinCodeDictionary[pinCode] = ZoneEnums.Green;
                }
            }
        }

        public static List<string> GetZoneInfo(string pincode)
        {
            List<string> result = new List<string>();

            if (pinCodeDictionary.ContainsKey(pincode) && pincodeMap.ContainsKey(pincode))
            {
                result.Add(pincodeMap[pincode].ToString());
                result.Add(pinCodeDictionary[pincode].ToString());
            }
            return result;
        }
    }
}
