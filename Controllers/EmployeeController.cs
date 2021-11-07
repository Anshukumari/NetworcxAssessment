using EmpManagement.Data;
using EmpManagement.Data.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmpManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var emp = _context.Employees.SingleOrDefault(e => e.Id == id);
            if (emp == null)
            {
                return NotFound("Employee with the Id" + id + " does not exist");
            }
            return Ok(emp);    
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = _context.Employees.SingleOrDefault(e => e.Id == id);
            if(emp==null)
            {
                return NotFound("Employee with the Id"+id+" does not exist");
            }
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return Ok("Employee with the Id"+id+" has been deleted");
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            var emp = _context.Employees.SingleOrDefault(e => e.Id == employee.Id);
            if (emp != null)
            {
                return Conflict("Employee with the Id" + employee.Id + " already exist");
            }
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Created(uri:"api/employees/"+employee.Id,employee);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            var emp = _context.Employees.SingleOrDefault(e => e.Id == id);
            if (emp == null)
            {
                return NotFound("Employee with the Id" + id + " does not exist");
            }
            if(employee.Name!=null)
            {
                emp.Name = employee.Name;
            }
            if(employee.Gender!=null)
            {
                emp.Gender = employee.Gender;
            }
            if (employee.Age != 0)
            {
                emp.Age = employee.Age;
            }
            if (employee.Salary != 0)
            {
                emp.Salary = employee.Salary;
            }
            _context.Update(emp);
            _context.SaveChanges();
            return Ok("Employee with the Id" + id + " has been Updated Successfully");
        }


    }
}
