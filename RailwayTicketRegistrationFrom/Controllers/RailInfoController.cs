using Microsoft.AspNetCore.Mvc;
using RailwayTicketRegistrationFrom.Models;

namespace RailwayTicketRegistrationFrom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RailInfoController : Controller
    {
        private readonly RailwayDbContext _context;
        public RailInfoController(RailwayDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDetails() 
        {
            var users=_context.railRegiInfos.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")] 
        public IActionResult GetById(int id) 
        {
            var user = _context.railRegiInfos.Find(id);
            if(user == null)
            {
                return BadRequest("Record Not founr");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Insertuser(int id, RailRegiInfo user)
        {
            if(user == null)
            {
                return BadRequest("Record Not found");
            }
            _context.railRegiInfos.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpPut("{id}")] 
        public IActionResult UpdateUser(int id,RailRegiInfo user)
        {
            var existinguser = _context.railRegiInfos.Find(id);
            if(existinguser== null)
            {
                return NotFound("User Not Found");
            }
            existinguser.Pfirstname=user.Pfirstname;
            existinguser.Pfirstname = user.Plastname;
            existinguser.pgender=user.pgender;
            existinguser.page=user.page;
            existinguser.pdob=user.pdob;
            existinguser.pmobile=user.pmobile;
            existinguser.pemail=user.pemail;
            existinguser.padhar=user.padhar;
            existinguser.pdate=user.pdate;
            existinguser.pfrom=user.pfrom;
            existinguser.pto=user.pto;
            _context.SaveChanges();
             
            return Ok(existinguser); 
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id) 
        {
            var user= _context.railRegiInfos.Find( id);
            if (user == null)
            {
                return NotFound("User Not Found");
            }
            _context.Remove(user);
            _context.SaveChanges();
            return Ok("User Data Sucessfully Deletedd");
        }
    }
}
