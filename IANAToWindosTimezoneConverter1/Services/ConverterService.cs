using IANAToWindosTimezoneConverter1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TimeZoneConverter;

namespace IANAToWindosTimezoneConverter1.Services
{
    public class ConverterService
    {
        public Response ConvertFromIanaTz(Request data)
        {
            string result;
            try
            {
                result = TZConvert.IanaToWindows(data.Name);
            }
            catch (TimeZoneNotFoundException)
            {
                result = $"Unable to find the {data.Name} zone in the registry, or it has been corrupted";
            }
            catch (InvalidTimeZoneException)
            {
                result = $"Unable to find the {data.Name} zone in the registry, or it has been corrupted";
            }
            
            return new Response { Result = result };
        }
        public Response ConvertFromWindosTz(Request data)
        {
            string result;
            try
            {
                result = TZConvert.WindowsToIana(data.Name);
            }
            catch (TimeZoneNotFoundException)
            {
                result = $"Unable to find the {data.Name} zone in the registry, or it has been corrupted";

            }
            catch (InvalidTimeZoneException)
            {
                result = $"Unable to find the {data.Name} zone in the registry, or it has been corrupted";
            }

            return new Response { Result = result };
        }
        public Response ConvertDateTime(DateTimeRequest data)
        {
            string result;
            try
            {
                TimeZoneInfo timeZoneFrom = TZConvert.GetTimeZoneInfo(data.TimeZoneNameFrom);
                TimeZoneInfo timeZoneTo = TZConvert.GetTimeZoneInfo(data.TimeZoneNameTo);
                var newTime = TimeZoneInfo.ConvertTime(data.Date, timeZoneFrom, timeZoneTo);
                result = newTime.ToString(); 
            }
            catch (TimeZoneNotFoundException)
            {
                result = $"Unable TimeZoneNot to find the {data.TimeZoneNameFrom} or {data.TimeZoneNameTo} zone in the registry, or it has been corrupted.";
            }
            catch (InvalidTimeZoneException)
            {
                result = $"Unable TimeZoneNot to find the {data.TimeZoneNameFrom} or {data.TimeZoneNameTo} zone in the registry, or it has been corrupted.";
            }
            return new Response { Result = result };
        }
       
    }
}
