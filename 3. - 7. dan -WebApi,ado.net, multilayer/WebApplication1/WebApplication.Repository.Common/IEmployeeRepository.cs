using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Model.Common;
using WebApplicationModel;

namespace WebApplication.Repository.Common
{
    public interface IEmployeeRepository
    {
        Task<int> GetEmployeeCountAsync(List<IEmployeeModel> employees);
        Task<List<IEmployeeModel>> ReturnEmployeeInfoAsync(int id);

        Task InsertNewEmployeeAsync(IEmployeeModel newEmployee);

        Task DeleteEmployeeFromRecordsAsync(int id);
    }
}
