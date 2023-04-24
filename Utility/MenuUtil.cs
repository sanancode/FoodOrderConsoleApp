using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderConsoleApp.Utility
{
    internal class MenuUtil
    {
        public static void Menu1()
        {
            // Welcome-dan sonraki ilk menyu

            Console.WriteLine(
                "\n1. Register as a Customer" +
                "\n2. Register as an Owner" +
                "\n3. Already have an account?" +
                "\n4. Show all customers" +
                "\n5. Show all owners" +
                "\n6. Login as an admin" +
                "\n7. Exit the system");
        }

        public static void Menu2ForCustomer()
        {
            // Already have an account menyusu
            // Customerler ucun

            Console.WriteLine(
                "\n1. Order a meal" +
                "\n2. History" +
                "\n3. Show all restaurants" +
                "\n4. Edit other informations" +
                "\n5. Back to previous menu");
        }

        public static void Menu2ForOwner()
        {
            // Already have an account menyusu
            // Ownerler ucun

            Console.WriteLine(
                "\n1. Add menu" +
                "\n2. Edit menu" +
                "\n3. Delete menu" +
                "\n4. Edit other informations" +
                "\n5. Back to previous menu");
        }

        public static void AdminMenu()
        {
            Console.WriteLine(
                "\n1. All profiles" +
                "\n2. All restaurants" +
                "\n3. All addresses" +
                "\n4. Add new address" +
                "\n5. Delete address" +
                "\n6. Back to previous menu");
        }
    }
}
