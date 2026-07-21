using EmployeeApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers;

/// <summary>
/// Employee Controller - Manages employee operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class EmpController : ControllerBase
{
    private static readonly List<Employee> Employees = new()
    {
        new Employee { Id = 1, Name = "Alice Johnson", Salary = 5000m },
        new Employee { Id = 2, Name = "Bob Smith", Salary = 6500m },
        new Employee { Id = 3, Name = "Charlie Brown", Salary = 7200m }
    };

    /// <summary>
    /// Get all employees
    /// </summary>
    /// <returns>List of all employees</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<IEnumerable<Employee>> GetAll()
    {
        return Ok(Employees);
    }

    /// <summary>
    /// Get employee by ID
    /// </summary>
    /// <param name="id">Employee ID</param>
    /// <returns>Employee details</returns>
    [HttpGet("{id:int}", Name = "GetEmployeeById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<Employee> GetById(int id)
    {
        var employee = Employees.FirstOrDefault(e => e.Id == id);
        if (employee is null)
        {
            return NotFound($"Employee with ID {id} not found");
        }

        return Ok(employee);
    }

    /// <summary>
    /// Create a new employee
    /// </summary>
    /// <param name="employee">Employee data</param>
    /// <returns>Created employee with ID</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<string> Create([FromBody] Employee employee)
    {
        if (employee is null || string.IsNullOrEmpty(employee.Name))
        {
            return BadRequest("Employee name is required");
        }

        employee.Id = Employees.Count > 0 ? Employees.Max(e => e.Id) + 1 : 1;
        Employees.Add(employee);
        return CreatedAtRoute("GetEmployeeById", new { id = employee.Id }, "Employee Added");
    }

    /// <summary>
    /// Update an existing employee
    /// </summary>
    /// <param name="id">Employee ID</param>
    /// <param name="employee">Updated employee data</param>
    /// <returns>Success message</returns>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<string> Update(int id, [FromBody] Employee employee)
    {
        if (employee is null || string.IsNullOrEmpty(employee.Name))
        {
            return BadRequest("Employee name is required");
        }

        var existingEmployee = Employees.FirstOrDefault(e => e.Id == id);
        if (existingEmployee is null)
        {
            return NotFound($"Employee with ID {id} not found");
        }

        existingEmployee.Name = employee.Name;
        existingEmployee.Salary = employee.Salary;
        return Ok("Employee Updated");
    }

    /// <summary>
    /// Delete an employee
    /// </summary>
    /// <param name="id">Employee ID</param>
    /// <returns>Success message</returns>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<string> Delete(int id)
    {
        var employee = Employees.FirstOrDefault(e => e.Id == id);
        if (employee is null)
        {
            return NotFound($"Employee with ID {id} not found");
        }

        Employees.Remove(employee);
        return Ok("Employee Deleted");
    }
}
