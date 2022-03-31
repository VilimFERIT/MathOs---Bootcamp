using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Model.Common;

namespace WebApplicationModel
{
    public class EmployeeModel : IEmployeeModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public bool EmploymentStatus { get; set; } = true;
    }
}
