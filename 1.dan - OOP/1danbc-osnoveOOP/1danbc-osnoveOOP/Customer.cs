using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1danbc_osnoveOOP
{
    public class Customer : Person
    { 
        public DateTime DateOfOrder { get; set; }
        public Adress Adress  { get; set; }

        public override void ChangeAdress(Adress newAdress)
        {
            this.Adress = newAdress;
        }
    }
}
