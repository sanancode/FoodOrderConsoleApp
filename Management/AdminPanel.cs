using FoodOrderConsoleApp.Models;
using FoodOrderConsoleApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace FoodOrderConsoleApp.Management
{
    internal class AdminPanel
    {
        public static void LoginAdmin()
        {
            Console.WriteLine("\nAdmin Panel\n");

            string admin = CommonMethods.getString("Admin: ");
            string password = CommonMethods.getString("Password: ");

            if(admin == "admin" && password == "admin")
            {
                RunAdmin();
            }
            else
            {
                Console.WriteLine("\nLogin or Password is not valid...Please try again...");
                LoginAdmin();
                return;
            }
        }

        public static void RunAdmin()
        {
            MenuUtil.AdminMenu();
            int menu = CommonMethods.selectMenuAbove();

            if (CommonMethods.CheckMenuBetween(menu, 1, 6))
            {
                switch (menu)
                {
                    case 1:
                        showAllProfiles();
                        RunAdmin();
                        break;
                    case 2:
                        showAllRestaurants();
                        RunAdmin();
                        break;
                    case 3:
                        showAllAddresses();
                        RunAdmin();
                        break;
                    case 4:
                        addNewAddress();
                        RunAdmin();
                        break;
                    case 5:
                        deleteAddress();
                        RunAdmin();
                        break;
                    case 6:
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nPlease select the menu between 1 and 6...Try again please...\n");
                RunAdmin();
                return;
            }
        }

        static void showAllProfiles()
        {
            Console.WriteLine("\nAll profiles...");
            int row = 1;

            for (int i = 0; i < Storage.profiles.Count; i++)
            {
                Console.WriteLine(
                    $"\n{row}. {Storage.profiles[i].Fullname}" +
                    $"\n - Login: {Storage.profiles[i].Login}" +
                    $"\n  - Password:  {Storage.profiles[i].Login}");
                row++;
            }
        }

        static void showAllRestaurants()
        {
            Console.WriteLine("\nAll restaurants...\n");
            int row = 1;

            for (int i = 0; i < Storage.profiles.Count; i++)
            {
                Owner owner = (Owner)Storage.profiles[i];
                if (owner.Type == "O")
                {
                    Console.WriteLine($"{row}. {owner.RestaurantName}");
                }
                row++;
            }
        }

        static void showAllAddresses()
        {
            Console.WriteLine("\nAll addresses...\n");
            int row = 1;

            for (int i = 0; i < Storage.addresses.Count; i++)
            {
                Console.WriteLine($"{row}. {Storage.addresses[i].AddressName}");
                row++;
            }
        }

        static void addNewAddress()
        {
            Console.WriteLine("\nAdd new address...\n");

            string newaddress = CommonMethods.getString("Please write address: ");
            float deliveryfee = CommonMethods.getFloat("Please write delivery fee: ");

            Storage.addresses.Add(new Address(newaddress, deliveryfee));

            Console.WriteLine($"\n{newaddress} added to the system...\n");
        }

        static void deleteAddress()
        {
            //Ilk once butun addresler gosteririlir
            showAllAddresses();

            string prevaddressname = "";
            int addressindex = CommonMethods.getInteger("\nPlease select the address above: ");

            if (CommonMethods.CheckMenuBetween(addressindex, 1, Storage.addresses.Count))
            {
                prevaddressname = Storage.addresses[addressindex - 1].AddressName;
                Storage.addresses.RemoveAt(addressindex - 1);
            }
            else
            {
                Console.WriteLine($"\nPlease select the menu between 1 and {Storage.addresses.Count}");
                deleteAddress();
                return;
            }

            Console.WriteLine($"\n{prevaddressname} deleted...\n");
        }
    }
}
