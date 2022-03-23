using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1danbc_osnoveOOP
{
    public class Company
    {
    public string Name { get; set; }
    public Adress Adress { get; set; }

    public Guid Id { get; set; }

    List<Employee> employees;
    List<Order> orders;

    
    }
}
