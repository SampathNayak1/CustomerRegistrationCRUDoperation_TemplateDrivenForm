using Microsoft.EntityFrameworkCore;

namespace ProductDeatails_TemplateForm.Models
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<ProductInfo> products { get; set; } 
    }
}
