using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderConsoleApp.Models
{
    internal class Sort
    {
        public string MealName { get; set; }
        public float Price { get; set; }

        public Sort(string sortname, float price)
        {
            this.MealName = sortname;
            this.Price = price;
        }
    }
}
