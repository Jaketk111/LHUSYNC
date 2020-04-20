using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attempt2.Models
{
    public class DaysChecked
    {
        public bool monday { get; set; }
        public bool tuesday { get; set; }
        public bool wednesday { get; set; }
        public bool thursday { get; set; }
        public bool friday { get; set; }
        public bool saturday { get; set; }
        public bool sunday { get; set; }

        public List<string> daysAvaiable = new List<string>();

        public List<string> timesAvailable = new List<string>();

    }
}
