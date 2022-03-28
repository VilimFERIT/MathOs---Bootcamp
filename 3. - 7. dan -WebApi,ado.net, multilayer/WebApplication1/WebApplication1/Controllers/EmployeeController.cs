using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class EmployeeController : ApiController
    {

        //danasnja lit-https://www.tutorialsteacher.com/webapi/what-is-web-api
        //nastavak koda na treci dan (api)
        // GET api/values

        [HttpGet]

        [Route("webapi/countemployees")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, $"There are {employees.Count} people working for this company.");
        }

        // GET api/values/5
        

        [HttpGet]

        [Route("webapi/getemployee")] //?id=1
        public HttpResponseMessage ReturnEmployeeName(int id)
        {
            
            Employee foundEmployee = employees.Find(employee => employee.Id == id);
            if (foundEmployee == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"The employee that you are looking for is not in the database!") ;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Found, foundEmployee);
            }
        }

        //POST api/values
     

        static List<Employee> employees = new List<Employee>();
        static List<DateTime> newStartingDates = new List<DateTime>();
        static List<DateTime> newEndingDates = new List<DateTime>();

        [HttpPost]

        [Route("webapi/newemployee")]
        public async Task<HttpResponseMessage> InsertNewEmployee(Employee newEmployee)  //stvara novog zaposlenika te ga sprema u listu
        {
            employees.Add(newEmployee);
            Employee employee = new Employee();
            
            employee.Id = employees.Last().Id;
            employee.FirstName = employees.Last().FirstName;
            employee.LastName = employees.Last().LastName;
            newStartingDates.Add(DateTime.Now);
            employee.StartingDates = newStartingDates;
            return Request.CreateResponse(HttpStatusCode.OK, $"A new employee {employee.FirstName} {employee.LastName} with Id#{Convert.ToString(employee.Id)} has been added to the database on {employee.StartingDates.Last()}!");
            }
            


        // PUT api/values/5
        //?id=1
        [HttpPut]

        [Route("webapi/employeestatus")]
        public HttpResponseMessage UpdateEmploymentStatus(int id)
        {
            Employee foundEmployee = employees.Find(employee => employee.Id == id);
            if (foundEmployee == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                foundEmployee.EmploymentStatus = !foundEmployee.EmploymentStatus;
                
                if (foundEmployee.EmploymentStatus == false)
                {
                    newEndingDates.Add(DateTime.Now);
                    foundEmployee.EndingDates = newEndingDates;
                    return Request.CreateResponse(HttpStatusCode.Found, $"{foundEmployee.FirstName} {foundEmployee.LastName} no longer works for this company as of {foundEmployee.EndingDates.Last()}!");
                }
                else
                {
                    List<DateTime> newStartingDates = new List<DateTime>();
                    newStartingDates.Add(DateTime.Now);
                    foundEmployee.StartingDates = newStartingDates;
                    return Request.CreateResponse(HttpStatusCode.Found, $"{foundEmployee.FirstName} {foundEmployee.LastName} is hired again as of {foundEmployee.EndingDates.Last()}!");
                }
            }

        }

        // DELETE api/values/5

        [HttpDelete]
        public HttpResponseMessage DeleteEmployeeFromRecords([FromBody]int id)
        {
            Employee deletedEmployee = employees.Find(employee => employee.Id == id);
            if (deletedEmployee == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                employees.Remove(deletedEmployee);
                return Request.CreateResponse(HttpStatusCode.Found, $"You have deleted an employee from the database!");
            }
        }

    
    }
}
