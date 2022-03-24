
using System;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    public class Employee
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public List<DateTime> StartingDates { get; set; }

        public  List<DateTime> EndingDates  { get; set; }

        public bool EmploymentStatus { get; set; } = true;

    }
}