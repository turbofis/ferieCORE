using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kollektapi.Data;
using Microsoft.EntityFrameworkCore;
using kollektapi.Models;

namespace kollektapi.Controllers
{
    [Route("api/[controller]")]
    public class ExpenseController : Controller
    {
        private readonly KollektivContext _context;

        public ExpenseController(KollektivContext context)
        {
            _context = context;

        }
        [Route("[action]",Name = "GetExpense")]
        public IActionResult GetExpense (int id)
        {
            var exp = _context.Expenses.Include(em => em.ExpenseMembers).Single(e => e.ExpenseId == id);
            return new ObjectResult(exp);
        }
        [Route("[action]", Name = "GetExpenseMember")]
        public IActionResult GetExpenseMember(int id)
        {
            var exp = _context.ExpenseMembers.Single(em => em.ExpenseMemberId == id);
            return new ObjectResult(exp);
        }
        [Route("[action]",Name ="PostExpense")]
        public IActionResult PostExpense([FromBody] Expense e)
        {
            _context.Expenses.Add(e);
            _context.SaveChanges();
            return CreatedAtRoute("GetExpense", new { id = e.ExpenseId }, value: e);
        }
        [Route("[action]", Name = "PostExpenseMember")]
        public IActionResult PostExpenseMember([FromBody] ExpenseMember e)
        {
            _context.ExpenseMembers.Add(e);
            _context.SaveChanges();
            return CreatedAtRoute("GetExpenseMember", new { id = e.ExpenseMemberId }, value: e);
        }
    }
}
