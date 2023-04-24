using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderConsoleApp.Models
{
    internal class Address
    {
        public string AddressName { get; set; }
        public float Fee { get; set; }

        public Address(string address, float fee)
        {
            this.AddressName = address;
            this.Fee = fee;
        }

    }

    

}
