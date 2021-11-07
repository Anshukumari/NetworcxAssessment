using EmpManagement.Data;
using EmpManagement.Data.Model;
using EmpManagement.IServices;
using EmpManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmpManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet("get-all-employees")]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = _service.GetEmployees();
            return Ok(allEmployees);
        }

        [HttpGet("get-employee-byId/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var emp = _service.GetEmployeeById(id);
            if (emp == null)
            {
                return NotFound("Employee with the Id" + id + " does not exist");
            }
            return Ok(emp);
        }

        [HttpPost("add-new-employee")]
        public IActionResult AddEmployee([FromBody] EmployeeVM employee)
        {
            _service.AddEmployee(employee);
            return Created(uri: "api/employees/" + employee.Name, employee);
        }

        [HttpPut("update-employee/{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeVM employee)
        {
            var emp = _service.UpdateEmployee(id, employee);
            if (emp == null)
            {
                return NotFound("Employee with the Id" + id + " does not exist");
            }
            return Ok("Employee with the Id" + id + " has been Updated Successfully");
        }

        [HttpDelete("delete-employee-byId/{id}")]
        public IActionResult Delete(int id)
        {
            bool isDeleted = _service.Delete(id);
            if(isDeleted)
            {
                return Ok("Employee with the Id" + id + " has been deleted");
            }
           else
            {
                return Ok("Employee does not exist");
            }
        }
    }
}
