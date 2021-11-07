using EmpManagement.Data;
using EmpManagement.Data.Model;
using EmpManagement.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmpManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDbContext _context;
        public EmployeeService(EmployeeDbContext context)
        {
            _context = context;
        }
        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }
        public void AddEmployee(EmployeeVM employee)
        {
            var _employee = new Employee()
            {
                Name = employee.Name,
                Gender = employee.Gender,
                Age = employee.Age,
                Salary = employee.Salary
            };
            _context.Employees.Add(_employee);
            _context.SaveChanges();
        }
        public Employee UpdateEmployee(int id, EmployeeVM employee)
        {
            var _employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (_employee != null)
            {
                _employee.Name = employee.Name;
                _employee.Age = employee.Age;
                _employee.Gender = employee.Gender;
                _employee.Salary = employee.Salary;
            }
            _context.Update(_employee);
            _context.SaveChanges();
            return _employee;
        }
        public bool Delete(int id)
        {
            var emp = _context.Employees.SingleOrDefault(e => e.Id == id);
            if (emp == null)
            {
                /* when employee is not available*/
                return false;
            }
            _context.Employees.Remove(emp);
            _context.SaveChanges();

            /* when employee is available*/
            return true;
        }
    }
}
