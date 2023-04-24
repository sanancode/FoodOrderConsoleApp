using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderConsoleApp.Utility
{
    internal class CommonMethods
    {
        public static string getString(string title)
        {
            Console.Write(title);
            return Console.ReadLine();
        }
        public static int getInteger(string title)
        {
            Console.Write(title);
            return int.Parse(Console.ReadLine());
        }
        public static float getFloat(string title)
        {
            Console.Write(title);
            return float.Parse(Console.ReadLine());
        }
        public static int selectMenuAbove()
        {
            Console.Write("Please select the menu above: ");
            return int.Parse(Console.ReadLine());
        }

        public static bool CheckMenuBetween(int menu, int min, int max)
        {
            if (min <= menu && menu <= max)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool checkExistProfiles()
        {
            //eger sistem de qeydiyyatdan kecmis profil varsa true return etsin

            if (Storage.profiles.Count > 0) return true;
            return false;
        }
    }
}
