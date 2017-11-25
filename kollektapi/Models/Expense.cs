using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kollektapi.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public string ExpenseName { get; set; }
        public DateTime Date { get; set; }
        public string Owner { get; set; }
        public int TotalAmount { get; set; }
        public string AmountCurrency { get; set; }
        public int NrOfMembers { get; set; }
        public bool Completed { get; set; }

        public int GroupId { get; set; }
        public ICollection<ExpenseMember> ExpenseMembers { get; set; }


    }
}
