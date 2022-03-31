using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Model.Common;
using WebApplication.Repository.Common;
using WebApplicationModel;

namespace WebApplicationRepository
{
    public class EmployeeRepository :IEmployeeRepository
    {
        public static string connectionString = @"Data Source=DESKTOP-KKL4FN6\SQLEXPRESS;Initial Catalog = vjezba; Integrated Security = True";
        public async Task<int> GetEmployeeCountAsync(List<IEmployeeModel> employees)
        {

            SqlConnection connection = new SqlConnection(connectionString);

            using (SqlCommand command = new SqlCommand($"SELECT * FROM Employee", connection))
            {
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<IEmployeeModel> employeeCount = new List<IEmployeeModel>();
                while (await reader.ReadAsync())
                {
                    EmployeeModel employee = new EmployeeModel();
                    employeeCount.Add(employee);
                }
                return employeeCount.Count;


            }

        }

        public async Task<List<IEmployeeModel>> ReturnEmployeeInfoAsync(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (SqlCommand command = new SqlCommand($"SELECT * FROM Employee WHERE Id ='{id}'", connection))
            {
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<IEmployeeModel> employees = new List<IEmployeeModel>();

                while (await reader.ReadAsync())
                {
                    EmployeeModel employee = new EmployeeModel();
                    employee.Id = reader.GetInt32(0);
                    employee.FirstName = reader.GetString(1);
                    employee.LastName = reader.GetString(2);
                    employee.Gender = reader.GetString(4);
                    employee.EmploymentStatus = reader.GetBoolean(3);
                    
                    employees.Add(employee);
                }
                return employees;
            }

        }

        public async Task InsertNewEmployeeAsync(IEmployeeModel newEmployee)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();

            using (connection)
            {
                await connection.OpenAsync();
                string newProductCommand = $"INSERT INTO Employee (Id, FirstName, LastName, Gender) VALUES('{newEmployee.Id}', {newEmployee.FirstName}, '{newEmployee.LastName}', '{newEmployee.Gender}');";
                adapter.InsertCommand = new SqlCommand(newProductCommand, connection);
                await adapter.InsertCommand.ExecuteNonQueryAsync();

            }

        }

        public async Task DeleteEmployeeFromRecordsAsync(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (SqlCommand command = new SqlCommand($"DELETE FROM Employee WHERE	Id = '{id}'", connection))
            {
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();

            }
        }
    }
}
