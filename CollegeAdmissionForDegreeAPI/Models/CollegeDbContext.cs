using Microsoft.EntityFrameworkCore;

namespace CollegeAdmissionForDegreeAPI.Models
{
    public class CollegeDbContext:DbContext
    {
        public CollegeDbContext(DbContextOptions<CollegeDbContext> options) : base(options) { }

       public DbSet<CollegeDegreeInfo> Students {  get; set; } 
    }
}
