using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPIsample_.Models;
using webAPIsample_.Services;

namespace webAPIsample_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<List<Employee>> GetAllEmployees()
        {
            List<Employee> employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }


        [HttpPost]
        public ActionResult<string> AddEmployee([FromBody] Employee employee)
        {
            return Ok(_employeeService.AddEmployee(employee));
        }


        [HttpPut]
        public ActionResult<string> UpdateEmployee(string name, [FromBody] Employee employee)
        {
            int status = _employeeService.UpdateEmployee(name, employee);
            if (status == 1)
            {
                return Ok("Employee updated");
            }
            return NotFound("Employee not found");

        }


        [HttpDelete]
        public ActionResult<string> DeleteEmployee(string name)
        {
            var status = _employeeService.DeleteEmployee(name);
            if (status)
            {
                return Ok("Employee updated");
            }
            return NotFound("Employee not found");
        }
    }
}