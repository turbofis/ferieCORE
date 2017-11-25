using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kollektapi.Data;
using kollektapi.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace kollektapi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly KollektivContext _context;

        public UserController(KollektivContext context)
        {
            _context = context;

        }

        [Route("[action]", Name = "GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var user = _context.Users.ToList();
            return new ObjectResult(user);
        }
        [Route("[action]", Name = "GetUser")]
        public IActionResult GetUser(int id)
        {
            var user = _context.Users.Single(g => g.UserId == id);
            return new ObjectResult(user);
        }
        [Route("[action]", Name ="GetUserExpenses")]
        public IActionResult GetUserExpenses(int id)
        {
            var user = _context.Users.Include(e => e.ExpenseMembers).Single(u => u.UserId == id);
            return new ObjectResult(user);
        }
        [Route("[action]", Name ="PostUser")]
        public IActionResult PostUser([FromBody] User s)
        {
            _context.Users.Add(s);
            _context.SaveChanges();
            return CreatedAtRoute("GetUser", new { id = s.UserId }, value: s);
        }
    }
}
