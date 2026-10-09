using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VoterCradregistrartionCrud.Models;

namespace VoterCradregistrartionCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoterInfoController : ControllerBase
    {
        private readonly VoterDbContext _context;

        public VoterInfoController(VoterDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            var users = _context.voter.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _context.voter.Find(id);
            if(user == null)
            {
                return BadRequest("User Not Found"); 
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult InsertUser(VoterRegInfo user) 
        {
            
            if (user == null)
            {
                return BadRequest("User Not Found ");
            }
            _context.voter.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, VoterRegInfo user)
        {
            var existinguser = _context.voter.Find(id);
            if(existinguser == null)
            {
                return NotFound("User Not Found");
            } 
            existinguser.Fullname=user.Fullname;
            existinguser.Dob=user.Dob;
            existinguser.Father=user.Father;
            existinguser.Mobile=user.Mobile;
            existinguser.Address=user.Address;
            existinguser.Adhardetails=user.Adhardetails;
            _context.SaveChanges( );
            return Ok(existinguser);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.voter.Find(id);

            if (user == null)
            {
                return NotFound("User Not Found"); 
            }
            _context.voter.Remove(user);
            _context.SaveChanges();
            return Ok(user);
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
