using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTS_Project
{
    class Calls
    {
        public string AreaCode { get; set; }
        public string FirstThreeDigits { get; set; }
        public string LastFourDigits { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }

        public Calls (string area, string first, string last, DateTime start, DateTime end) 
        {
            AreaCode = area;
            FirstThreeDigits = first;
            LastFourDigits = last;
            Begin = start;
            End = end;
        }
        string toString()
        {
            return AreaCode+FirstThreeDigits+LastFourDigits;
        }
    }
}
