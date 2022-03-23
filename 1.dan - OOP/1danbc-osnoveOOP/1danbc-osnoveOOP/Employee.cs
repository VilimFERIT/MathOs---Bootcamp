using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1danbc_osnoveOOP
{
    public class Employee : Person
    {
        public DateTime StartOfEmployment { get; set; }

        public Adress Adress { get; set; }

        public override void ChangeAdress(Adress newAdress)
        {
            this.Adress = newAdress;
        }

    }
}
