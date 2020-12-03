using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IANAToWindosTimezoneConverter1.Models
{
    public class DateTimeRequest
    {
        public DateTime Date { get; set; }
        public string TimeZoneNameFrom { get; set; }
        public string TimeZoneNameTo { get; set; }
    }
}
