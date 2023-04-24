using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderConsoleApp.Models
{
    internal class Customer : Person
    {
        public List<CustomerHistory> CustomerHistory { get; set; }

        public Customer(string fullname, string type, string login, string password) : base(fullname, type, login, password)
        {
            CustomerHistory = new List<CustomerHistory>();
        }
    }
}
