using firtdotnetcore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firtdotnetcore.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);

        IEnumerable<Employee> GetEmployees();

        Employee addEmployee(Employee employee);
    }
}
