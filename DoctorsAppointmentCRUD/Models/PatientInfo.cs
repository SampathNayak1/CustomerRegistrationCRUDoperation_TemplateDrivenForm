using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorsAppointmentCRUD.Models
{
    [Table("DoctorAppointment")]
    public class PatientInfo 
    {
        [Key]
        public int PatinentID { get; set; }
        public string PatientName { get; set; }
        public string PatientGender { get; set; }    
        public int PatientAge { get; set; }
        public string PatientBloodGroup { get; set; }
        public string PatientDisease { get; set; }
        public string  PatientTest { get; set; }
        public string PatientPhoneNumber { get; set; }
        public string PatientAddress { get; set; }
        public string PatientEmailID  { get; set; }
        public string DoctorName { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string AppointmentFeePaid { get; set; }
    }
}
