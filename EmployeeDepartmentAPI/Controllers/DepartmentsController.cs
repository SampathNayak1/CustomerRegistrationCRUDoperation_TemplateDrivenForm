using EmployeeDepartmentAPI.Data;
using EmployeeDepartmentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        // GET: api/Departments/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
                return NotFound();

            return department;
        }

        // POST: api/Departments
        [HttpPost]
        public async Task<ActionResult<Department>> CreateDepartment(
            Department department)
        {
            _context.Departments.Add(department);

            await _context.SaveChangesAsync();

            return Ok(department);
        }

        // PUT: api/Departments/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(
            int id,
            Department department)
        {
            if (id != department.DepartmentId)
                return BadRequest();

            _context.Entry(department).State =
                EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok(department);
        }

        // DELETE: api/Departments/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department =
                await _context.Departments.FindAsync(id);

            if (department == null)
                return NotFound();

            var hasEmployees =
                await _context.Employees
                    .AnyAsync(e => e.DepartmentId == id);

            if (hasEmployees)
            {
                return BadRequest(
                    "Cannot delete department because employees are assigned to it.");
            }

            _context.Departments.Remove(department);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}