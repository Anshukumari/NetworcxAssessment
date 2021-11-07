using EmpManagement.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpManagement.Repository
{
   public interface IEmployeeRepository
    {
        // Method to retrieve all employee details
        IEnumerable<Employee> GetEmployees();

        // Method to retrieve detail for a particular employee based on employee Id
        Employee GetEmployeeById(int id);

        // Method to add an employee 
        void AddEmployee(EmployeeVM employee);

        // Method to edit details of an employee 
        Employee UpdateEmployee(int id, EmployeeVM employee);

        // Method to update details partially 
        Employee UpdateEmployeePatch(int id, JsonPatchDocument employee);

        // Method to delete a particular employee based on employee Id
        bool Delete(int id);
    }
}
