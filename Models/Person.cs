using FoodOrderConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderConsoleApp
{
    internal class Person
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Type { get; set; } // C, O

        public Person(string fullname, string type, string login, string password)
        {
            this.Fullname = fullname;
            this.Type = type;
            Login = login;
            Password = password;

        }
    }
}
