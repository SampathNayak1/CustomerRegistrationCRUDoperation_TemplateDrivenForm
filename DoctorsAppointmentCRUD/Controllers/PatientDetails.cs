using DoctorsAppointmentCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsAppointmentCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientDetails : ControllerBase
    {
        private readonly PatientDbContext _context;
        public PatientDetails(PatientDbContext context)
        {
            _context= context;    
        }

        [HttpGet]
        public IActionResult GetDetails()
        {
            var users=_context.patientInfos.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetDetailsById(int id)
        {
            var user = _context.patientInfos.Find(id);
            if (user == null)
            {
                return BadRequest("User Not Found");
            }
            return Ok(user); 
        } 
        [HttpPost]
        public IActionResult InsertDetails(int id, PatientInfo user)
        {
            if (user == null)
            {
                return BadRequest("User Not Found");
            }
            _context.patientInfos.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateDetails(int id,PatientInfo user )
        {
              var existingUser=_context.patientInfos.Find(id);
            if (existingUser == null)
            {
                return NotFound("User Not Found");
            }
            existingUser.PatientName = user.PatientName;
            existingUser.PatientGender = user.PatientGender;
            existingUser.PatientAge = user.PatientAge;
            existingUser.PatientBloodGroup = user.PatientBloodGroup;
            existingUser.PatientDisease = user.PatientDisease;
            existingUser.PatientTest = user.PatientTest;
            existingUser.PatientPhoneNumber = user.PatientPhoneNumber;
            existingUser.PatientAddress = user.PatientAddress;
            existingUser.PatientEmailID = user.PatientEmailID;
            existingUser.DoctorName = user.DoctorName;
            existingUser.AppointmentDate = user.AppointmentDate;
            existingUser.AppointmentTime = user.AppointmentTime;
            existingUser.AppointmentFeePaid = user.AppointmentFeePaid;
            _context.SaveChanges();
            return Ok(existingUser);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDetails(int id)
        {
            var user = _context.patientInfos.Find(id);
            if (user == null)
            {
                return NotFound("User Not Found");
            }
            _context.patientInfos.Remove(user);
            _context.SaveChanges();
            return Ok("User Deleted Sucesfully");
        }
 
    }
}
