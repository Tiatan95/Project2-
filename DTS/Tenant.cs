using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTS_Project
{
    class Tenant
    {
        public List<Calls> phoneCalls = new List<Calls>();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccessCode { get; set; }
        public List<Bar> barredNumbers = new List<Bar>();

        public Tenant(string first, string last, string access)
        {
            FirstName = first;
            LastName = last;
            AccessCode = access;
        }

    }
}
