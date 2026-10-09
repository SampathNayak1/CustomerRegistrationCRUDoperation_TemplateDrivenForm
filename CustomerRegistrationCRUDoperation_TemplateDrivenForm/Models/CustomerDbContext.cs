using Microsoft.EntityFrameworkCore;

namespace CustomerRegistrationCRUDoperation_TemplateDrivenForm.Models
{
    public class CustomerDbContext:DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options):base(options)
        {
        }
        public DbSet<CustomerInfo> customers { get; set; }
    }
}
