using firtdotnetcore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firtdotnetcore.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
        {
            new Employee() { Id = 1, Name = "Mary", Department = Dept.HR, Email = "mary@pragimtech.com" },
            new Employee() { Id = 2, Name = "John", Department = Dept.IT, Email = "john@pragimtech.com" },
            new Employee() { Id = 3, Name = "Sam", Department = Dept.Payroll, Email = "sam@pragimtech.com" },
        };
        }

        public Employee addEmployee(Employee employee)
        {
            employee.Id = _employeeList.Max(a => a.Id) + 1;
           this._employeeList.Add(employee);
            return employee;

        }

        public Employee GetEmployee(int Id)
        {
            return this._employeeList.Where(a => a.Id == Id).FirstOrDefault();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return this._employeeList;
        }
    }
}
