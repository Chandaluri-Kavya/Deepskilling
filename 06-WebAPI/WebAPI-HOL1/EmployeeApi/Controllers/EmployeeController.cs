using EmployeeApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private static readonly List<Employee> Employees = new()
    {
        new Employee { Id = 1, Name = "Alice", Salary = 5000m },
        new Employee { Id = 2, Name = "Bob", Salary = 6500m }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Employee>> GetAll()
    {
        return Ok(Employees);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Employee> GetById(int id)
    {
        var employee = Employees.FirstOrDefault(e => e.Id == id);
        if (employee is null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpPost]
    public ActionResult<string> Create([FromBody] Employee employee)
    {
        if (employee is null)
        {
            return BadRequest("Employee data is required");
        }

        employee.Id = Employees.Count > 0 ? Employees.Max(e => e.Id) + 1 : 1;
        Employees.Add(employee);
        return Ok("Employee Added");
    }

    [HttpPut("{id:int}")]
    public ActionResult<string> Update(int id, [FromBody] Employee employee)
    {
        if (employee is null)
        {
            return BadRequest("Employee data is required");
        }

        var existingEmployee = Employees.FirstOrDefault(e => e.Id == id);
        if (existingEmployee is null)
        {
            return NotFound("Employee not found");
        }

        existingEmployee.Name = employee.Name;
        existingEmployee.Salary = employee.Salary;
        return Ok("Employee Updated");
    }

    [HttpDelete("{id:int}")]
    public ActionResult<string> Delete(int id)
    {
        var employee = Employees.FirstOrDefault(e => e.Id == id);
        if (employee is null)
        {
            return NotFound("Employee not found");
        }

        Employees.Remove(employee);
        return Ok("Employee Deleted");
    }
}
