using FoodOrderConsoleApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderConsoleApp.Management
{
    internal class CustomerOperationManagement
    {
        public static void GoSelectedMenuForCustomer(int custindex)
        {
            MenuUtil.Menu2ForCustomer();
            int menu = CommonMethods.selectMenuAbove();

            if (CommonMethods.CheckMenuBetween(menu, 1, 7))
            {
                switch (menu)
                {
                    case 1: //Order a meal
                        OrderAMeal(custindex);
                        GoSelectedMenuForCustomer(custindex);
                        break;
                    case 2: //History
                        History(custindex);
                        GoSelectedMenuForCustomer(custindex);
                        break;
                    case 3: //Show all restaurants
                        ShowAllRestaurants();
                        GoSelectedMenuForCustomer(custindex);
                        break;
                    case 4: //Edit other informations
                        EditOtherInformations(custindex);
                        GoSelectedMenuForCustomer(custindex);
                        break;
                    case 5:
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nPlease select the menu between 1 and 7...Try again please...\n");
                GoSelectedMenuForCustomer(custindex);
                return;
            }
        }


        static void OrderAMeal(int custindex)
        {
            Console.WriteLine("\nOrder a meal\n");
            int row = 1;
            float totalPrice = 0;
            string answer = "";
            Owner owner = null;
            List<string> restaurantsArray = new List<string>();
            List<string> categorymenuArray = new List<string>();
            List<string> sortmenuArray = new List<string>();
            List<float> sortmenupriceArray = new List<float>();

            do
            {
                //ilk once restoranlari ekrana cap etmelidir
                for (int i = 0; i < Storage.profiles.Count; i++) //profiller uzre addimlama
                {
                    if (Storage.profiles[i].Type == "O") //ownere beraberdirse
                    {
                        owner = (Owner)Storage.profiles[i];
                        Console.WriteLine($"{row}. {owner.RestaurantName},  Rate: {owner.Rating}");
                        restaurantsArray.Add(owner.RestaurantName);
                    }
                }

                //cap edilen restoranlar arasindan biri secilir
                int restaurantindex = CommonMethods.getInteger("\nPlease select the restaurant above: ");
                string restaurant = restaurantsArray[restaurantindex - 1];

                //secilen restoranin category menyusu cap edilir
                row = 1;
                for (int i = 0; i < Storage.profiles.Count; i++) //profiller uzre addimlama
                {
                    if (Storage.profiles[i].Type == "O") //ownere beraberdirse
                    {
                        owner = (Owner)Storage.profiles[i];
                        for (int j = 0; j < owner.MealMenu.Count; j++)
                        {
                            if (owner.RestaurantName == restaurant)
                            {
                                Console.WriteLine($"{row}. category: {owner.MealMenu[j].CategoryName}");
                                categorymenuArray.Add(owner.MealMenu[j].CategoryName);
                                row++;
                            }
                        }
                    }
                }

                //cap edilen categoryler arasindan biri secilir
                int categoryindex = CommonMethods.getInteger("\nPlease select the category above: ");
                string category = categorymenuArray[categoryindex - 1];

                //secilen category menyusunda olan sort cap edilir
                row = 1;
                for (int i = 0; i < Storage.profiles.Count; i++)
                {
                    if (Storage.profiles[i].Type == "O") //ownere beraberdirse
                    {
                        owner = (Owner)Storage.profiles[i];
                        for (int j = 0; j < owner.MealMenu.Count; j++)
                        {
                            for (int z = 0; z < owner.MealMenu[j].Sorts.Count; z++)
                            {
                                if (owner.MealMenu[j].CategoryName == category)
                                {
                                    Console.WriteLine($" - Meal: {owner.MealMenu[j].Sorts[z].MealName}");
                                    Console.WriteLine($" - Price: {owner.MealMenu[j].Sorts[z].Price}");
                                    sortmenuArray.Add(owner.MealMenu[j].Sorts[z].MealName);
                                    sortmenupriceArray.Add(owner.MealMenu[j].Sorts[z].Price);
                                }
                            }
                        }
                    }
                }

                //cap edilen sortlar arasindan biri secilir
                int sortindex = CommonMethods.getInteger("\nPlease select the meal above: ");
                string mealname = sortmenuArray[sortindex - 1]; //mehsulun adi

                //yekun olaraq elde dilen datalara uygun gelen qiymet tapilir
                for (int i = 0; i < Storage.profiles.Count; i++) //profiller uzre axtaris
                {
                    if (Storage.profiles[i].Type == "O") //ownere beraberdirse
                    {
                        owner = (Owner)Storage.profiles[i];

                        for (int j = 0; j < owner.MealMenu.Count; j++) //meal menyular category uzre axtaris
                        {
                            if (owner.MealMenu[j].CategoryName == category)
                            {
                                for (int k = 0; k < owner.MealMenu[j].Sorts.Count; k++) //sort uzre
                                {
                                    if (owner.MealMenu[j].Sorts[k].MealName == mealname)
                                    {
                                        totalPrice += owner.MealMenu[j].Sorts[k].Price;
                                        ((Models.Customer)Storage.profiles[custindex]).CustomerHistory.Add(new Models.CustomerHistory(mealname));
                                        goto exit;
                                    }
                                }
                            }
                        }
                    }
                }
            exit:;

                //delivery fee
                float deliveryfee = Storage.addresses[restaurantindex - 1].Fee;
                totalPrice += deliveryfee;

                //Final
                Console.WriteLine($"\nTotal price: {totalPrice}");

                answer = CommonMethods.getString("\nAnother order? (Y/N): ");
            } while (answer == "Y");

            Console.WriteLine("\nOrder finished...");
            Console.WriteLine("Have a taste of your meal...");
            Console.WriteLine("Thank you to choose us...");
            Console.WriteLine("Have a nice day...");

        }

        static void History(int custindex)
        {
            Console.WriteLine("\nAll Histories...\n");
            int row = 1;

            Models.Customer customer = (Models.Customer)Storage.profiles[custindex];

            if (customer.CustomerHistory.Count > 0)
            {
                for (int i = 0; i < customer.CustomerHistory.Count; i++)
                {
                    Console.WriteLine(
                        $"{row}. Order: {customer.CustomerHistory[i].Order}" +
                        $" Date: {customer.CustomerHistory[i].Date}");
                    row++;
                }
            }
            else
            {
                Console.WriteLine("\nThere is not any operation in this profile...\n");
            }
        }

        static void ShowAllRestaurants()
        {
            Console.WriteLine("\nAll Restaurants...\n");
            int row = 1;

            for (int i = 0; i < Storage.profiles.Count; i++)
            {
                if (Storage.profiles[i].Type == "O")
                {
                    Owner owner = (Owner)Storage.profiles[i];

                    Console.WriteLine($"{row}. {owner.RestaurantName}");
                    row++;
                }
            }
        }

        static void EditOtherInformations(int custindex)
        {
            Console.WriteLine(
                "\nEditing choice" +
                "\n1. Fullname" +
                "\n2. Login" +
                "\n3. Password" +
                "\n4. Back to previous menu");

            int menu = CommonMethods.selectMenuAbove();

            if (CommonMethods.CheckMenuBetween(menu, 1, 3))
            {
                switch (menu)
                {
                    case 1:
                        EditInformations(custindex, 1);
                        EditOtherInformations(custindex);
                        break;
                    case 2:
                        EditInformations(custindex, 2);
                        EditOtherInformations(custindex);
                        break;
                    case 3:
                        EditInformations(custindex, 3);
                        EditOtherInformations(custindex);
                        break;
                    case 4:
                        break;
                }
            }
        }

        #region Edit Other Informations Method
        static void EditInformations(int custindex, int infoindex)
        {
            if (infoindex == 1) //fullname
            {
                Console.WriteLine($"\nCurrent fullname: {Storage.profiles[custindex].Fullname}");
                string prefullname = Storage.profiles[custindex].Fullname;
                string newfullname = CommonMethods.getString("Please write your new fullname: ");
                Storage.profiles[custindex].Fullname = newfullname;

                Console.WriteLine($"Fullname {prefullname} changed with {newfullname}");
            }
            else if (infoindex == 2) //login
            {
                Console.WriteLine($"\nCurrent login: {Storage.profiles[custindex].Login}");
                string prelogin = Storage.profiles[custindex].Login;
                string newlogin = CommonMethods.getString("Please write your new login: ");
                Storage.profiles[custindex].Login = newlogin;

                Console.WriteLine($"Login {prelogin} changed with {newlogin}");
            }
            else //password
            {
                Console.WriteLine($"\nCurrent password: {Storage.profiles[custindex].Password}");
                string prepassword = Storage.profiles[custindex].Password;
                string newpassword = CommonMethods.getString("Please write your new password: ");
                Storage.profiles[custindex].Password = newpassword;

                Console.WriteLine($"Password {prepassword} changed with {newpassword}");
            }
        }
        #endregion
    }
}
