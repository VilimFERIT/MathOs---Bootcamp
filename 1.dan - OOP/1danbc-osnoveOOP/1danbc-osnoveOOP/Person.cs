using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1danbc_osnoveOOP
{
    public abstract class Person
    {

       public string FirstName { get; set; }
       public string LastName { get; set; }

       private int OIB { get; set; }

        public abstract void ChangeAdress(Adress newAdress);
        
    }
}
