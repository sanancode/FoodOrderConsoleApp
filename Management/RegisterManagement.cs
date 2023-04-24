using FoodOrderConsoleApp.Models;
using FoodOrderConsoleApp.Models;
using FoodOrderConsoleApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderConsoleApp.Management
{
    internal class RegisterManagement
    {
        public static void RegisterCustomer()
        {
            Console.WriteLine("\n\tCustomer Registration...\n");

            string fullname = CommonMethods.getString("Fullname: ");
            string login = CommonMethods.getString("Login: ");

            if (checkLogin(login)) //sistemde login artiq istifade olunursa
            {
                Console.WriteLine("\nLogin is already used...Please Try again...\n");
                RegisterOwner();
                return;
            }

            string password = CommonMethods.getString("Password: ");

            Storage.profiles.Add(new Customer(fullname, "C", login, password));

            Console.WriteLine("\nRegistration Completed...");
            Console.WriteLine($"{fullname} added...");
        }

        public static void RegisterOwner()
        {
            //bu registration sadece adsoyad, tip, ve restoran adini qeydiyyatdan kecirir
            //restoranin menyusunu elave etmek ikinci etapda olur

            Console.WriteLine("\n\tOwner Registration...\n");

            string fullname = CommonMethods.getString("Fullname: ");
            string login = CommonMethods.getString("Login: ");

            if (checkLogin(login)) //sistemde login artiq istifade olunursa
            {
                Console.WriteLine("\nLogin is already used...Please Try again...\n");
                RegisterOwner();
                return;
            }

            string password = CommonMethods.getString("Password: ");
            string restaurantname = CommonMethods.getString("Restaurant name: ");

            int addressint = getAddress();
            string addressname = Storage.addresses[addressint - 1].AddressName;

            //ownerin liste daxil edilmesi
            Person owner = new Owner(fullname, "O", restaurantname, addressname, login, password);
            Storage.profiles.Add(owner);

            Console.WriteLine("\nRegistration Completed...");
            Console.WriteLine(
                $"{fullname} added..." +
                $"\nRestaurant name: {restaurantname}" +
                $"\nAddress: {addressname}");
        }

        static int getAddress()
        {
            int addressint = 0;

            //qeydiyyatda olan addresleri gosterir
            for (int i = 0; i < Storage.addresses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Storage.addresses[i].AddressName}");
            }

            //esas proses
            do
            {
                addressint = CommonMethods.getInteger("Please select the addresses above: ");

                if (CommonMethods.CheckMenuBetween(addressint, 1, Storage.addresses.Count))
                {
                    return addressint;
                }
                Console.WriteLine($"\nSelection must be between 1 and {Storage.addresses.Count}");

            } while (!CommonMethods.CheckMenuBetween(addressint, 1, Storage.addresses.Count));

            return addressint;
        }

        static bool checkLogin(string login)
        {
            //true return ederse sistemde daha evvelden qeydiyyatdan kecmis
            //qeyd edilmis login var demekdir

            for (int i = 0; i < Storage.profiles.Count; i++)
            {
                if (Storage.profiles[i].Login == login)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
