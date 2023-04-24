using FoodOrderConsoleApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderConsoleApp.Management
{
    internal class LoginManagement
    {
        public static int LoginTheSystem()
        {
            Console.WriteLine("\nPlease fill the sections below to login the system...\n");

            do
            {
                string login = CommonMethods.getString("Login: ");
                string password = CommonMethods.getString("Password: ");

                for (int i = 0; Storage.profiles.Count > 0; i++)
                {
                    if (Storage.profiles[i].Login == login && Storage.profiles[i].Password == password)
                    {
                        return i;
                    }
                }

                Console.WriteLine("\nThere is not registered login or password in the system...Try again please...\n");
            } while (true);

        }
    }
}
