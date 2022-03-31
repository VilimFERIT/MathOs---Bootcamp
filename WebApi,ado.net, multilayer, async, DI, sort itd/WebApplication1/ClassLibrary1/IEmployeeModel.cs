using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Model.Common
{
    public interface IEmployeeModel
    {
        int Id { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string Gender { get; set; }

        bool EmploymentStatus { get; set; }
    }
}
