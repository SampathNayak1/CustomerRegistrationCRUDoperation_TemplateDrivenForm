using Microsoft.EntityFrameworkCore;

namespace DoctorsAppointmentCRUD.Models
{
    public class PatientDbContext:DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options) { }

        public DbSet<PatientInfo> patientInfos { get; set; }
    }
}
