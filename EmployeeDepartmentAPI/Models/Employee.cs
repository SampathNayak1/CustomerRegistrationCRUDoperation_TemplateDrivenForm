using System.ComponentModel.DataAnnotations;

namespace EmployeeDepartmentAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        public string? Email { get; set; }

        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }

        // Navigation property
        public Department? Department { get; set; }
    }
}