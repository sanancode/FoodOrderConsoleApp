using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderConsoleApp.Models
{
    internal class MealMenu
    {
        public string CategoryName { get; set; }
        public List<Sort> Sorts { get; set; }

        public MealMenu(string categoryname)
        {
            this.CategoryName = categoryname;
            Sorts = new List<Sort>();
        }
    }
}
