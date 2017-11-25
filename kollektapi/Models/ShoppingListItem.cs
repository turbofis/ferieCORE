using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kollektapi.Models
{
    public class ShoppingListItem
    {
        
        public int ShoppinglistitemId { get; set; }
        
        public string Comodity { get; set; }
        public bool Check { get; set; }
        [DisplayFormat(NullDisplayText = "Not finished")]
        public string Checkedby { get; set; }

        public int ShoppinglistId { get; set; }
        
        public ShoppingList ShoppingList { get; set; }
    }
}
