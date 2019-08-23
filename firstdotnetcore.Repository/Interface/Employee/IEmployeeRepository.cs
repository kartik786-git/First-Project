using System;
using System.Collections.Generic;
using System.Text;
using firstdotnetcore.Entity;

namespace firstdotnetcore.Repository
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);

        IEnumerable<Employee> GetEmployees();

        Employee addEmployee(Employee employee);

        Employee Update(Employee employeeChanges);
        Employee Delete(int Id);
    }
}
