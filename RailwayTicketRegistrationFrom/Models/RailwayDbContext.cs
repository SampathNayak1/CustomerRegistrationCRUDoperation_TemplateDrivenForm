using Microsoft.EntityFrameworkCore;

namespace RailwayTicketRegistrationFrom.Models
{
    public class RailwayDbContext:DbContext
    {   
        public RailwayDbContext(DbContextOptions<RailwayDbContext> options) : base(options) { }

        public DbSet<RailRegiInfo> railRegiInfos { get; set; }
    }
}
