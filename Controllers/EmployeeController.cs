using EmpManagement.Models;
using EmpManagement.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmpManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _service;
        public EmployeeController(IEmployeeRepository service)
        {
            _service = service;
        }

        [HttpGet("getAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = _service.GetEmployees();
            return Ok(allEmployees);
        }

        [HttpGet("getEmployeeById/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var emp = _service.GetEmployeeById(id);
            if (emp == null)
            {
                return NotFound("Employee with the Id" + id + " does not exist");
            }
            return Ok(emp);
        }

        [HttpPost("addNewEmployee")]
        public IActionResult AddEmployee([FromBody] EmployeeVM employee)
        {
            _service.AddEmployee(employee);
            return Created(uri: "api/employees/" + employee.Name, employee);
        }

        [HttpPut("updateEmployee/{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeVM employee)
        {
            var emp = _service.UpdateEmployee(id, employee);
            if (emp == null)
            {
                return NotFound("Employee with the Id" + id + " does not exist");
            }
            return Ok("Employee with the Id " + id + " has been Updated Successfully");
        }

        [HttpPatch("updatePartially/{id}")]
        public IActionResult UpdateEmployeePatch(int id, [FromBody] JsonPatchDocument employee)
        {
            var emp = _service.UpdateEmployeePatch(id, employee);
            if (emp == null)
            {
                return NotFound("Employee with the Id" + id + " does not exist");
            }
            return Ok("Employee with the Id " + id + " has been Updated Successfully");
        }

        [HttpDelete("deleteEmployeeById/{id}")]
        public IActionResult Delete(int id)
        {
            bool isDeleted = _service.Delete(id);
            if(isDeleted)
            {
                return Ok("Employee with the Id " + id + " has been deleted");
            }
           else
            {
                return Ok("Employee does not exist");
            }
        }
    }
}
