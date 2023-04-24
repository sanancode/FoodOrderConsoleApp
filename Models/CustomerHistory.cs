using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderConsoleApp.Models
{
    internal class CustomerHistory
    {
        public string Order { get; set; }
        public string Date { get; set; }

        public CustomerHistory(string order)
        {
            this.Order = order;
            this.Date = DateTime.Now.ToString("dd.mm.yyyy - hh.mm.ss");
        }
    }
}
