using CustomerRegistrationCRUDoperation_TemplateDrivenForm.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRegistrationCRUDoperation_TemplateDrivenForm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  
    public class UserDataInfoController : Controller
    {
        private readonly CustomerDbContext _context;
           public UserDataInfoController(CustomerDbContext context)
              {
                     _context = context;
                 }
        [HttpGet]
        public IActionResult GetUser()
        {
            var users = _context.customers.ToList();
           
            return Ok(users);

        }

        [HttpGet("{id}")] 
        public IActionResult GetById(int id)
        {
            var user = _context.customers.Find(id);
            if(user == null)
            {
                return BadRequest("User Not Found");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser(CustomerInfo cust)
        {
            if(cust == null)
            {
                return BadRequest("User Not Found");
            }
            _context.customers.Add(cust);
            _context.SaveChanges();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id,CustomerInfo user)
        {
            var existngUser=_context.customers.Find(id);
            if (existngUser == null)
            {
                return NotFound("User Not Found"); 
            }

            existngUser.Cname = user.Cname;
            existngUser.Cemail= user.Cemail;
            existngUser.Cphone = user.Cphone;
            existngUser.Cproduct = user.Cproduct;
            existngUser.Cprice = user.Cprice;
            existngUser.Caddress = user.Caddress;
            _context.SaveChanges();
            return Ok(existngUser);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.customers.Find(id);
            if(user == null)
            {
                return NotFound("User Not Found");
            }
            _context.customers.Remove(user);
            _context.SaveChanges();
            return Ok("User Data Succesfully Deleted");
        }

    }
}
