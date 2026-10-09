using Microsoft.EntityFrameworkCore;

namespace VoterCradregistrartionCrud.Models
{
    public class VoterDbContext:DbContext
    {
        public VoterDbContext(DbContextOptions<VoterDbContext> options) : base(options) { }

        public DbSet<VoterRegInfo> voter { get; set; } 
    }
}
