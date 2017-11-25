using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kollektapi.Models
{
    public class Group
    {
        
        public int GroupId { get; set; }
        public string Name { get; set; }
        public ICollection<ShoppingList> ShoppingLists { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}
