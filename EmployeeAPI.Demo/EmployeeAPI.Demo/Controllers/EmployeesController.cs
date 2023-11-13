using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Demo.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private List<Employee> employees = new List<Employee>
    {
        // Initialize with some sample data
        new Employee { Id = 1, EmployeeName = "Tiger", EmployeeSalary = 320800, EmployeeAge = 61},
        new Employee { Id = 2, EmployeeName = "arya", EmployeeSalary = 320800, EmployeeAge = 21},
        new Employee { Id = 3, EmployeeName = "abinash", EmployeeSalary = 320800, EmployeeAge = 22},
        new Employee { Id = 4, EmployeeName = "randeep", EmployeeSalary = 320800, EmployeeAge = 23}

        // ... (add more data)
    };

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return employees;
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        [HttpPost]
        public ActionResult<Employee> Post(Employee employee)
        {
            employee.Id = employees.Count + 1; // Generate a new ID
            employees.Add(employee);
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Employee employee)
        {
            var existingEmployee = employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            existingEmployee.EmployeeName = employee.EmployeeName;
            existingEmployee.EmployeeSalary = employee.EmployeeSalary;
            existingEmployee.EmployeeAge = employee.EmployeeAge;
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            employees.Remove(employee);
            return NoContent();
        }
    }
}
