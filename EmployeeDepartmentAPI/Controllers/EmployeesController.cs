using EmployeeDepartmentAPI.Data;
using EmployeeDepartmentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _context.Employees
                .Include(e => e.Department)
                .Select(e => new
                {
                    e.EmployeeId,
                    e.EmployeeName,
                    e.Email,
                    e.Salary,
                    e.DepartmentId,
                    DepartmentName = e.Department.DepartmentName
                })
                .ToListAsync();

            return Ok(employees);
        }

        // GET: api/Employees/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Department)
                .Where(e => e.EmployeeId == id)
                .Select(e => new
                {
                    e.EmployeeId,
                    e.EmployeeName,
                    e.Email,
                    e.Salary,
                    e.DepartmentId,
                    DepartmentName = e.Department.DepartmentName
                })
                .FirstOrDefaultAsync();

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            var departmentExists =
                await _context.Departments
                    .AnyAsync(d => d.DepartmentId == employee.DepartmentId);

            if (!departmentExists)
            {
                return BadRequest("Invalid DepartmentId");
            }

            _context.Employees.Add(employee);

            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        // PUT: api/Employees/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(
            int id,
            Employee employee)
        {
            if (id != employee.EmployeeId)
                return BadRequest();

            var departmentExists =
                await _context.Departments
                    .AnyAsync(d => d.DepartmentId == employee.DepartmentId);

            if (!departmentExists)
                return BadRequest("Invalid DepartmentId");

            _context.Entry(employee).State =
                EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        // DELETE: api/Employees/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee =
                await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}