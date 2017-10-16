using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTS_Project
{
    class Bar
    {
        public string number { get; set; }
    }
    class BarArea:Bar
    {
       public BarArea(string area)
        {
            number = area;
        }
    }
    class BarNumber:Bar
    {
        public BarNumber(Calls number)
        {
            this.number = number.ToString(); 
        }
    }
}
