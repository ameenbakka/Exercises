using System.Xml.Linq;
using webAPIsample_.Models;

namespace webAPIsample_.Services
{
    public interface IEmployeeService
    {
        public List<Employee> GetAllEmployees();
        public Employee? GetByName(string name);

        public string AddEmployee(Employee employee);
        public int UpdateEmployee(string name, Employee employee);
        public bool DeleteEmployee(string name);

    }

    public class EmployeeService : IEmployeeService
    {
        public static List<Employee> employees = new List<Employee>();

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }
        public Employee? GetByName(string name)
        {
             return employees.FirstOrDefault(x => x.Name == name);
        }


        public string AddEmployee(Employee employee)
        {
            employees.Add(employee);
            return "Added employee successfully";

        }
        public int UpdateEmployee(string name, Employee employee)
        {
            Employee? emp = employees.FirstOrDefault(x => x.Name == name);
            if (emp == null)
            {
                return -1;
            }
            emp.Name = employee.Name;
            emp.Age = employee.Age;
            emp.Salary = employee.Salary;
            return 1;
        }
        public bool DeleteEmployee(string name)
        {
            Employee? emp = employees.FirstOrDefault(y => y.Name == name);
            if (emp == null)
            {
                return false;
            }
            employees.Remove(emp);
            return true;
        }
    }
}
