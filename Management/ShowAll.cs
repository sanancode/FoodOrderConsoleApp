using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderConsoleApp.Management
{
    internal class ShowAll
    {
        public static void ShowAllRegisteredCustomers()
        {
            int row = 1;

            if (checkRegisteredProfiles("C"))
            {
                Console.WriteLine("\nAll Registered Customers\n");

                for (int i = 0; i < Storage.profiles.Count; i++)
                {
                    if (Storage.profiles[i].Type == "C")
                    {
                        Console.WriteLine($"{row}. {Storage.profiles[i].Fullname}");
                        row++;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nThere is not any registered customers in the system...\n");
            }
        }

        public static void ShowAllRegisteredOwners()
        {
            int row = 1;

            if (checkRegisteredProfiles("O"))
            {
                for (int i = 0; i < Storage.profiles.Count; i++)
                {
                    if (Storage.profiles[i].Type == "O")
                    {
                        Owner owner = (Owner)Storage.profiles[i];

                        Console.WriteLine(
                            $"\n{row}. Owner: {owner.Fullname}" +
                            $"\n  Restaurant: {owner.RestaurantName}" +
                            $"\n  Rating: {owner.Rating}");

                        Console.WriteLine("...Menu...");
                        for (int j = 0; j < owner.MealMenu.Count; j++)
                        {
                            Console.WriteLine($"Category: {owner.MealMenu[j].CategoryName}");

                            for (int z = 0; z < owner.MealMenu[j].Sorts.Count; z++)
                            {
                                Console.WriteLine(
                                    $" - Meal: {owner.MealMenu[j].Sorts[z].MealName}" +
                                    $"  -  Price: {owner.MealMenu[j].Sorts[z].Price}");
                            }
                        }
                        row++;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nThere is not any registered owners in the system...\n");
            }
        }

        static bool checkRegisteredProfiles(string type)
        {
            //Bu metod ona gonderilen type ugun olaraqprofiles listinde uygun profil olub olmadigini kontrol edir
            // geri true return ederse var demekdir

            for (int i = 0; i < Storage.profiles.Count; i++)
            {
                if (Storage.profiles[i].Type == type) return true;
            }
            return false;
        }
    }
}
