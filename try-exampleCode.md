# C# Notes langz

```csharp

[HttpGet("{id}")]
public async Task<ActionResult<Review>> GetReview(int id) {
  try {
    Review result = await _dbContext.Reviews.FindAsync(id);
    if (result == null) {
      return NotFound($"Review with ID {id} not found.");
    }
    return Ok(result);
  } catch (Exception ex) {
    return StatusCode(500, $"Something went wrong: {ex.Message}");
  }
}

[HttpDelete("{id}")]
public async Task<ActionResult> DeleteComment(int id) {
  try {
    Comment result = await _dbContext.Comments.FindAsync(id);

    if (result == null) {
      return NotFound($"Comment with ID {id} not found.");
    }

    _dbContext.Comments.Remove(result);
    await _dbContext.SaveChangesAsync();

    return NoContent();
  } catch (Exception ex) {
    return StatusCode(500, $"Something went wrong: {ex.Message}");
  }
}

[HttpGet ("{id}")]
public async Task<ActionResult<Product>> GetAllCategory(int id) {
  try {
    Category result = await _dbContext.Category.FindAsync(id);

    if (result == null) return NotFound($"Result with ID {id} not Found.");

    return Ok(result);
  } catch (Exception ex) {
    return StatusCode(500, $"Something went wrong: {ex.Message}");
  }
}









//PATCHHHH
const handleSaveEmployeeInfo = async () => {
    const config = {
        headers: {
            Authorization: `Bearer ${accessToken}`,
            'Content-Type': 'application/json-patch+json' // required content type for JSON Patch
        },
        withCredentials: true
    };
    try {
        // Compare original data vs edited data, build ONLY the operations for what changed
        const patchOps = [];

        if (originalEmployee.salary !== newSalary) {
            patchOps.push({ op: "replace", path: "/salary", value: newSalary });
        }
        if (originalEmployee.department !== newDepartment) {
            patchOps.push({ op: "replace", path: "/department", value: newDepartment });
        }

        if (patchOps.length === 0) {
            console.log("No changes to save.");
            return;
        }

        await axios.patch(`/employees/${employeeId}`, patchOps, config);
        console.log("PATCH payload:", patchOps);
        toast.success("Employee Updated");
        fetchData();
    } catch (err) {
        toast.error("Failed to update employee");
        console.error("Failed to update employee: ", err);
    }
};

[HttpPatch("{id}")]
public async Task<ActionResult> PatchEmployee(int id, JsonPatchDocument<Employee> patchDoc)
{
    try
    {
        Employee existing = await _dbContext.Employees.FindAsync(id);

        if (existing == null)
            return NotFound($"Employee with ID {id} not found.");

        patchDoc.ApplyTo(existing); // applies ONLY the operations sent — nothing else touched

        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Something went wrong: {ex.Message}");
    }
}















[Route("api/[controller]")] // sets the URL prefix — "[controller]" auto-fills with the class name
                            // minus "Controller", so EmployeesController → api/employees
[ApiController]             // marks this as an API controller — turns on automatic
                            // request validation and clean error responses

public class EmployeesController : ControllerBase
{
  private readonly AppDbContext _dbContext; // field — permanent, holds the db connection

  public EmployeesController(AppDbContext dbContext) // parameter — temporary, only during construction
  {
    _dbContext = dbContext; // field = parameter — stores it permanently for every method to use
  }

  // GET: api/employees
  [HttpGet]
  public async Task<ActionResult<List<Employee>>> GetAllEmployees()
  {
    try
    {
      List<Employee> employees = await _dbContext.Employees.ToListAsync();
      return Ok(employees);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Something went wrong: {ex.Message}");
    }
  }

  // GET: api/employees/5
  [HttpGet("{id}")]
  public async Task<ActionResult<Employee>> GetEmployee(int id)
  {
    try
    {
      Employee emp = await _dbContext.Employees.FindAsync(id);

      if (emp == null)
        return NotFound($"Employee with ID {id} not found.");

      return Ok(emp);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Something went wrong: {ex.Message}");
    }
  }

  // POST: api/employees
  [HttpPost]
  public async Task<ActionResult<Employee>> CreateEmployee(Employee newEmployee)
  {
    try
    {
      // newEmployee comes in from the client, WITHOUT an ID yet:
      // { firstName: "Miguel", salary: 30000 }  ← no EmployeeID, client doesn't set it
      _dbContext.Employees.Add(newEmployee);
      await _dbContext.SaveChangesAsync();
      // ← THIS is where the database assigns the real ID, e.g. 6
      // after this line runs, newEmployee.EmployeeID is now automatically filled with 6

      return CreatedAtAction(nameof(GetEmployee), new { id = newEmployee.EmployeeID }, newEmployee);
      //                                                      ^^^^^^^^^^^^^^^^^^^^^^^
      //                                          this is 6 — the database ALREADY gave it to us
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Something went wrong: {ex.Message}");
    }
  }

  // PUT: api/employees/5
  [HttpPut("{id}")]
  public async Task<ActionResult> UpdateEmployee(int id, Employee updatedEmployee)
  {
    try
    {
      if (id != updatedEmployee.EmployeeID)
          return BadRequest("ID mismatch.");

      Employee emp = await _dbContext.Employees.FindAsync(id);
      if (emp == null)
          return NotFound();

      emp.FirstName = updatedEmployee.FirstName;
      emp.Salary = updatedEmployee.Salary;

      await _dbContext.SaveChangesAsync();
      return NoContent(); // 204 — success, nothing to send back
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Something went wrong: {ex.Message}");
    }
  }

  // DELETE: api/employees/5
  [HttpDelete("{id}")]
  public async Task<ActionResult> DeleteEmployee(int id)
  {
    try
    {
      Employee emp = await _dbContext.Employees.FindAsync(id);
      if (emp == null)
        return NotFound();

      _dbContext.Employees.Remove(emp);
      await _dbContext.SaveChangesAsync();
      return NoContent();
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Something went wrong: {ex.Message}");
    }
  }
}