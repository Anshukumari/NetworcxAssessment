using EmpManagement.Data.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmpManagement.IServices
{
   public interface IEmployeeService
    {
        // Method to retrieve all employee details
        IEnumerable<Employee> GetEmployees();

        // Method to retrieve detail for a particular employee based on employee Id
        Employee GetEmployeeById(int id);

        // Method to add an employee 
        void AddEmployee(EmployeeVM employee);

        // Method to edit details of an employee 
        Employee UpdateEmployee(int id, EmployeeVM employee);

        // Method to delete a particular employee based on employee Id
        bool Delete(int id);
    }
}
