using Microsoft.AspNetCore.Mvc;
using ProductDeatails_TemplateForm.Models;

namespace ProductDeatails_TemplateForm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductInfoController : Controller
    {
        private readonly ProductDbContext _context;
        public ProductInfoController(ProductDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Getusers()
        {
            var users=_context.products.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _context.products.Find(id);
            if (user == null)
            {
                return BadRequest("Record Not Found");
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Insertuser(ProductInfo obj)
        {
            if (obj == null)
            {
                return BadRequest("User Not Found");
            }
            _context.products.Add(obj);
            _context.SaveChanges();
            return Ok(obj);
        }

        [HttpPut("{id}")]
        public IActionResult Updateuser(int id, ProductInfo obj)
        {
            var existinguser = _context.products.Find(id);
            if (existinguser == null)
            {
                return NotFound("User Not Found");
            }
            existinguser.Productname = obj.Productname;
            existinguser.TotalPrice = obj.TotalPrice;
            existinguser.Quantity = obj.Quantity;
            existinguser.Paymentmode = obj.Paymentmode;
            existinguser.Delivaryaddress = obj.Delivaryaddress;
            _context.SaveChanges();
            return Ok(existinguser);

        }

        [HttpDelete("{id}")]
        public IActionResult Deleteuser(int id)
        {
            var user= _context.products.Find(id);
            if(user == null)
            {
                return  NotFound("User Not Found");
            }
            _context.products.Remove(user);
            _context.SaveChanges();
            return Ok("User Deleted Sucessfully");
            
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
