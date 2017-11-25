using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kollektapi.Models;

namespace kollektapi.Data
{
    public class DbInit
    {
        public static void Initialize(KollektivContext context)
        {
            context.Database.EnsureCreated();
            if(context.Groups.Any())
            {
                return;
            }
            var g1 = new Group { Name = "Bogstadveien 47" };
            var g2 = new Group { Name = "Jentekollektivet" };
            context.Groups.Add(g1);
            context.Groups.Add(g2);
            context.SaveChanges();

            var users = new User[]
            {
                new User {GroupID=1,Name="Manni"},
                new User {GroupID=1, Name="Geir"},
                new User {GroupID=1,Name="Kristine"},
                new User {GroupID=2,Name="Marianne"},
                new User {GroupID=2,Name="Mari"},
                new User {GroupID=2,Name="Kari"}
            };
            foreach(User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();
            
            var shoppingLists = new ShoppingList[]
            {
                new ShoppingList{GroupID=1,Name="Julebord",Completed=false,Date=DateTime.Parse("2017-10-02")},
                new ShoppingList{GroupID=1,Name="Fellesting",Completed=false,Date=DateTime.Parse("2017-12-03")},
                new ShoppingList{GroupID=2,Name="Innflytningsfest",Completed=false,Date=DateTime.Parse("2017-03-03")}
            };
            foreach (ShoppingList s in shoppingLists)
            {
                context.ShoppingLists.Add(s);
            }
            context.SaveChanges();

            var expenses = new Expense[]
            {
                new Expense{AmountCurrency="NOK",Completed=false,TotalAmount=300,ExpenseName="Internett",Date=DateTime.ParseExact("22/11/2016","dd/mm/yyyy",null),GroupId=1,NrOfMembers=3,Owner="Manni"},
                new Expense{AmountCurrency="NOK",Completed=false,TotalAmount=2000,ExpenseName="Ny oppvaskmaskin",Date=DateTime.ParseExact("22/11/2016","dd/mm/yyyy",null),GroupId=1,NrOfMembers=3,Owner="Manni"},
                new Expense{AmountCurrency="NOK",Completed=false,TotalAmount=450,ExpenseName="Strømregning",Date=DateTime.ParseExact("22/11/2016","dd/mm/yyyy",null),GroupId=2,NrOfMembers=3,Owner="Kari"}
            };
            foreach(Expense e in expenses)
            {
                context.Expenses.Add(e);
                
            }
            context.SaveChanges();

            var expensemembers = new ExpenseMember[]
            {
                new ExpenseMember{AmountCurrency="NOK",AmountToPay=100,ExpenseId=1,MemberName="Manni",UserId=1,Paid=false},
                new ExpenseMember{AmountCurrency="NOK",AmountToPay=100,ExpenseId=1,MemberName="Geir",UserId=2,Paid=true},
                new ExpenseMember{AmountCurrency="NOK",AmountToPay=100,ExpenseId=1,MemberName="Kristine",UserId=3,Paid=false},

                new ExpenseMember{AmountCurrency="NOK",AmountToPay=1000,ExpenseId=2,MemberName="Marianne",UserId=4,Paid=false},
                new ExpenseMember{AmountCurrency="NOK",AmountToPay=500,ExpenseId=2,MemberName="Mari",UserId=5,Paid=false},
                new ExpenseMember{AmountCurrency="NOK",AmountToPay=500,ExpenseId=2,MemberName="Kari",UserId=6,Paid=false},

                new ExpenseMember{AmountCurrency="NOK",AmountToPay=200,ExpenseId=3,MemberName="Manni",UserId=1,Paid=true},
                new ExpenseMember{AmountCurrency="NOK",AmountToPay=250,ExpenseId=3,MemberName="Geir",UserId=2,Paid=true}
            };

            foreach(ExpenseMember e in expensemembers)
            {
                context.ExpenseMembers.Add(e);
            }
            context.SaveChanges();

            var shoppinglistitems = new ShoppingListItem[]
            {
                new ShoppingListItem{ShoppinglistId=1,Check=false,Comodity="Julepølse"},
                new ShoppingListItem{ShoppinglistId=1,Check=false,Comodity="Poteter"},
                new ShoppingListItem{ShoppinglistId=1,Check=false,Comodity="Akevitt"},
                new ShoppingListItem{ShoppinglistId=1,Check=false,Comodity="Engangsbestikk"},
                new ShoppingListItem{ShoppinglistId=1,Check=false,Comodity="Julepynt"},
                new ShoppingListItem{ShoppinglistId=1,Check=false,Comodity="Pinnekjøtt"},
                new ShoppingListItem{ShoppinglistId=1,Check=true,Checkedby="Manni",Comodity="Kålrotstappe"},
                new ShoppingListItem{ShoppinglistId=1,Check=false,Comodity="Ribbe"},

                new ShoppingListItem{ShoppinglistId=2,Check=false,Comodity="Dopapir"},
                new ShoppingListItem{ShoppinglistId=2,Check=false,Comodity="Zalo"},
                new ShoppingListItem{ShoppinglistId=2,Check=false,Comodity="Håndsåpe"},
                new ShoppingListItem{ShoppinglistId=2,Check=false,Comodity="Ny stekepanne"},

                new ShoppingListItem{ShoppinglistId=3,Check=true,Checkedby="Marianne",Comodity="Øltønne"},
                new ShoppingListItem{ShoppinglistId=3,Check=true,Checkedby="Mari",Comodity="Ballonger"},
                new ShoppingListItem{ShoppinglistId=3,Check=true,Checkedby="Kari",Comodity="Pølser"}

            };
            foreach(ShoppingListItem si in shoppinglistitems)
            {
                context.ShoppingListItems.Add(si);
            }
            
            

            context.SaveChanges();
        }
    }
}
