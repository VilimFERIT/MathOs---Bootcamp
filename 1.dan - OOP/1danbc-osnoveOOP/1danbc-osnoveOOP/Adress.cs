using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1danbc_osnoveOOP
{
    public class Adress
    {
        public string Country { get; set; }
        public string City { get; set; }
        public int Postcode { get; set; }

        public string StreetAndNumber { get; set; }

        public string ReturnAdress()
        {
            return $"{Country}, {City}, {Postcode}, {StreetAndNumber}";
        }
    }
}
