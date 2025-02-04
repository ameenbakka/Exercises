using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2_new.Models;
using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class EmployeeController : ControllerBase
    {

        public readonly IEmployeeServices _EmployeeServices;

        public EmployeeController(IEmployeeServices employeeServices)
        {

            _EmployeeServices = employeeServices;
        }

        [HttpGet("AllEmployees")]

        public IActionResult GetAllEmployee()
        {
            var AllEmp = _EmployeeServices.getEmployee();

            return Ok(AllEmp);
        }

        [HttpPost]

        public IActionResult AddEmp(Employee ademp)
        {
            var isAdded = _EmployeeServices.AddEmployee(ademp);

            return Ok(isAdded);
        }

        [HttpDelete("DeleteEmployee/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteEmp(int id)
        {
            var result = _EmployeeServices.DeleteEmployee(id);

            if (result == "Employee Not found")
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpPut]

        public IActionResult updatedEmployee(int id, Employee updtedEmployee)
        {

            var isUpdated = _EmployeeServices.UpdatedEmployee(id, updtedEmployee);

            if (isUpdated == null)
            {
                return NotFound();
            }
            return Ok(isUpdated);
        }

        [HttpGet("SearchStudents")]

        public IActionResult Serach(string keyword)
        {
            var isSerached = _EmployeeServices.SearchEmployee(keyword);

            if (isSerached.Count == 0)
            {
                return NotFound();
            }
            return Ok(isSerached);
        }
    }
}