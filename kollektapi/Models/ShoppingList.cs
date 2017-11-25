using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kollektapi.Models
{
    public class ShoppingList
    {

        
        public int ShoppinglistId { get; set; }
        public int GroupID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool Completed { get; set; }

        public ICollection<ShoppingListItem> ShoppingListItems { get; set; }

        public Group Group { get; set; }

    }
}
