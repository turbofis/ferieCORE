
using Microsoft.EntityFrameworkCore;
using kollektapi.Models;
namespace kollektapi.Data
{
    public class KollektivContext : DbContext
    {
        public KollektivContext(DbContextOptions<KollektivContext> options)
            : base (options)
        {
            
        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ShoppingListItem> ShoppingListItems { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseMember> ExpenseMembers { get; set; }
    }
}
