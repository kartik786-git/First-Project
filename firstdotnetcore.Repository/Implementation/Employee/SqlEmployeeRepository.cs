﻿using firstdotnetcore.DataAccess;
using firstdotnetcore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace firstdotnetcore.Repository
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDBContext _context;
        public SQLEmployeeRepository(AppDBContext context)
        {
            this._context = context;
        }


        public Employee addEmployee(Employee employee)
        {
            this._context.Add(employee);
            this._context.SaveChanges();
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = _context.Employees.Find(Id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return employee;
        }

        public Employee GetEmployee(int Id)
        {
            return _context.Employees.Find(Id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees;
        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = _context.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return employeeChanges;
        }
    }
}
