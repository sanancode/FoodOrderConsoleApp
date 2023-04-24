using FoodOrderConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderConsoleApp
{
    internal class Owner : Person
    {
        public string RestaurantName { get; set; }
        public double Rating { get; set; }
        public List<MealMenu> MealMenu { get; set; }
        public string AddressName { get; set; }

        public Owner(string fullname, string type, string restaurantname, string addressname, string login, string password) : base(fullname, type, login, password)
        {
            this.RestaurantName = restaurantname;
            this.AddressName = addressname;

            //initialize
            this.Rating = 0;
            MealMenu = new List<MealMenu>();

        }
    }
}
