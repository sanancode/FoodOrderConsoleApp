using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrderConsoleApp.Models;

namespace FoodOrderConsoleApp
{
    internal class Storage
    {
        public static List<Person> profiles = new List<Person>();
        public static List<Address> addresses = new List<Address>();

        #region Address Names and Fees
        //Bu addresler ve ededler proyekt ise duserken initialize edilen melumatlardir
        //Yeniden eger address daxil etmek isteyerlerse o zaman bir basa addresses listine daxil edilecekdir

        public static string[] addressname =
            {
            "Binaqadi",
            "Qaradagh",
            "Khazar",
            "Sabail",
            "Sabunchu",
            "Surakhani",
            "Narimanov",
            "Nasimi",
            "Nizami",
            "Pirallahi",
            "Khatai",
            "Yasamal"
        };

        public static float[] addressfee = { 3, 5, 3, 4, 4, 4, 4, 5, 5, 6, 4, 4 };

        public static void LoadAllAddressesToSystem()
        {
            for (int i = 0; i < addressname.Length; i++) { addresses.Add(new Address(addressname[i], addressfee[i])); }
        }
        #endregion

    }

}
