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
    public class ListController : Controller
    {
        private readonly KollektivContext _context;
        
        public ListController (KollektivContext context)
        {
            _context = context;
            
        }
        [Route("[action]",Name ="GetAllShoppingLists")]
        public IEnumerable<ShoppingListItem> GetAllShoppingLists()
        {
            
            return _context.ShoppingListItems.ToList();
        }
        [Route("[action]", Name = "GetShoppingList")]

        public IActionResult GetShoppingList(int id)
        {
            try
            {
                var list = _context.ShoppingLists.Single(s => s.ShoppinglistId == 1);
                _context.Entry(list).Collection(b => b.ShoppingListItems).Load();
                

                if (list == null)
                {
                    return NotFound();
                }
                return new ObjectResult(list);
            }catch(Exception ex)
            {
                var list = ex.Message;
                return new ObjectResult(list);
            }
        }
        [Route("[action]",Name ="PostShoppingList")]
        public IActionResult PostShoppingList ([FromBody] ShoppingList sl)
        {
            if (sl == null)
                return BadRequest();
            _context.ShoppingLists.Add(sl);
            _context.SaveChanges();

            return CreatedAtRoute(routeName:"GetShoppingList",routeValues: new { id = sl.ShoppinglistId }, value:sl);

        }
        [Route("[action]", Name = "PostShoppingListItem")]
        public IActionResult PostShoppingListItem ([FromBody] ShoppingListItem si)
        {
            if (si == null)
                return BadRequest();
            _context.ShoppingListItems.Add(si);
            _context.SaveChanges();

            return CreatedAtRoute("GetShoppingList", new { id = si.ShoppinglistId }, value: si);
            
        }

    }
}
