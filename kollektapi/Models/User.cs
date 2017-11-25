using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kollektapi.Models
{
    public class User
    {
        
        public int UserId { get; set; }
        public int GroupID { get; set; }
        public string Name { get; set; }
        public Group Group { get; set; }

        public ICollection<ExpenseMember> ExpenseMembers { get; set; }
    }
}
