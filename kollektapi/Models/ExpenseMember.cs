using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kollektapi.Models
{
    public class ExpenseMember
    {
        public int ExpenseMemberId { get; set; }
        public string MemberName { get; set; }
        public int AmountToPay { get; set; }
        public string AmountCurrency { get; set; }
        public bool Paid { get; set; }

        public int ExpenseId { get; set; }
        public Expense Expense { get; set; }


        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
