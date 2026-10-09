using CollegeAdmissionForDegreeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeAdmissionForDegreeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollegeInfoController : Controller
    {
        private CollegeDbContext _context;
        public CollegeInfoController(CollegeDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetStudentDetails()
        {
            var students = _context.Students.ToList();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentDetailsById(int id)
        {
            var student = _context.Students.Find(id);
            if(student == null)
            {
                return BadRequest("Record Not Foud");
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult InsertStudentDetails(int id, CollegeDegreeInfo stu )
        {
            if(stu== null)
            {
                return BadRequest("Student Not Fond");
            } 
            _context.Students.Add(stu);
            _context.SaveChanges();
            return Ok(stu);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudentDeatils(int id, CollegeDegreeInfo stu)
        {
            var existingstudent = _context.Students.Find(id);
            if(existingstudent == null)
            {
                return NotFound("Student Record Not Found");
            }
            existingstudent.Name = stu.Name;
            existingstudent.DateOfBirth = stu.DateOfBirth;
            existingstudent.Gender = stu.Gender;
            existingstudent.Age = stu.Age;  
            existingstudent.SSCPassedYear = stu.SSCPassedYear;
            existingstudent.SSCPercentage = stu.SSCPercentage;
            existingstudent.SchoolName = stu.SchoolName;
            existingstudent.IntermediateGroup= stu.IntermediateGroup;
            existingstudent.IntermediatePercentage = stu.IntermediatePercentage;
            existingstudent.IntermediatePassedYear = stu.IntermediatePassedYear;
            existingstudent.ExpectedDegreeGroup = stu.ExpectedDegreeGroup;
            existingstudent.MobileNumber = stu.MobileNumber;
            existingstudent.EmailID = stu.EmailID;
            existingstudent.AdmmissionStatus = stu.AdmmissionStatus;

            _context.SaveChanges();

            return Ok(existingstudent); 
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudentDeatils(int id)
        {
            var user = _context.Students.Find(id);
                if (user == null)
            {
                return NotFound("Student Not Found");
            }
                _context.Students.Remove(user);
            _context.SaveChanges();
            return Ok("Student Data Deleted Sucessfully ");
        }

       
    }
}
