using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Model.Common;
using WebApplication.Repository.Common;
using WebApplication.Service.Common;
using WebApplicationModel;

namespace WebApplicationService
{
    public class EmployeeService : IEmployeeService
    {
        public IEmployeeRepository Repository {get; set;}

        public EmployeeService(IEmployeeRepository repository)
        {
            Repository = repository;
        }

        public async Task<int> GetEmployeeCountAsync(List<IEmployeeModel> employees)
        {
            return await Repository.GetEmployeeCountAsync(employees);
        }
        
        public async Task<List<IEmployeeModel>> ReturnEmployeeInfoAsync(int id)
        {
            return await Repository.ReturnEmployeeInfoAsync(id);
        }

        public async Task InsertNewEmployeeAsync(IEmployeeModel newEmployee)
        {
            await Repository.InsertNewEmployeeAsync(newEmployee);
        }

        public async Task DeleteEmployeeFromRecordsAsync(int id)
        {
            await Repository.DeleteEmployeeFromRecordsAsync(id);
        }
    }
}
