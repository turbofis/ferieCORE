using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kollektapi.Models;
using kollektapi.Data;
using Microsoft.EntityFrameworkCore;

namespace kollektapi.Controllers
{
    [Route("api/[controller]")]
    public class GroupController : Controller
    {
        private readonly KollektivContext _context;

        public GroupController(KollektivContext context)
        {
            _context = context;

        }

        [Route("[action]", Name = "GetAllGroups")]
        public IActionResult GetAllGroups()
        {
            var group = _context.Groups.ToList();
            return new ObjectResult(group);
        }
        [Route("[action]", Name="GetGroup")]
        public IActionResult GetGroup(int id)
        {
            var group = _context.Groups.Single(g => g.GroupId == id);
            return new ObjectResult(group);
        }
        [Route("[action]", Name = "GetGroupUsers")]
        public IActionResult GetGroupUsers(int id)
        {
            var group = _context.Groups.Single(g => g.GroupId == id);
            _context.Entry(group).Collection(u => u.Users).Load();
            return new ObjectResult(group);
        }
        [Route("[action]", Name = "GetGroupLists")]
        public IActionResult GetGroupLists(int id)
        {
            var group = _context.Groups.Include(l => l.ShoppingLists)
                                        .ThenInclude(li => li.ShoppingListItems).Single(g => g.GroupId == id);
            return new ObjectResult(group);
        }
        [Route ("[action]",Name ="GetGroupExpenses")]
        public IActionResult GetGroupExpenses(int id)
        {
            var group = _context.Groups.Include(e => e.Expenses)
                                        .ThenInclude(em => em.ExpenseMembers).Single(g => g.GroupId == id);
            return new ObjectResult(group);
        }


        [Route("[action]",Name ="PostGroup")]
        public IActionResult PostGroup ([FromBody] Group g)
        {
            _context.Groups.Add(g);
            _context.SaveChanges();
            return CreatedAtRoute("GetGroup", new { id = g.GroupId }, value:g);

        }

    }
}
