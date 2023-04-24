using FoodOrderConsoleApp.Models;
using FoodOrderConsoleApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderConsoleApp.Management
{
    internal class OwnerOperationManagement
    {
        public static void GoSelectedMenuForOwner(int ownindex)
        {
            MenuUtil.Menu2ForOwner();
            int menu = CommonMethods.selectMenuAbove();

            if (CommonMethods.CheckMenuBetween(menu, 1, 5))
            {
                switch (menu)
                {
                    case 1: // Add menu
                        AddMenu(ownindex);
                        GoSelectedMenuForOwner(ownindex);
                        break;
                    case 2: // Edit menu
                        EditMenu(ownindex);
                        GoSelectedMenuForOwner(ownindex);
                        break;
                    case 3: // Delete menu
                        DeleteMenu(ownindex);
                        GoSelectedMenuForOwner(ownindex);
                        break;
                    case 4: // Edit other informations
                        EditOtherInformations(ownindex);
                        GoSelectedMenuForOwner(ownindex);
                        break;
                    case 5:
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nPlease select the menu between 1 and 5...Try again please...\n");
                GoSelectedMenuForOwner(ownindex);
                return;
            }
        }


        #region AddMenu
        static void AddMenu(int ownindex)
        {
            Console.WriteLine("\nAdd menu...\n");
            int row = 1;
            List<string> categoryarray = new List<string>();

            //ilk once yeni kateqori yoxsa olan categorye menu elave etmek istediyini sorusur
            Console.WriteLine(
                "1. New Category" +
                "\n2. Add sorts into existing category" +
                "\n3. Back to previous menu");
            int menu = CommonMethods.selectMenuAbove();

            if (CommonMethods.CheckMenuBetween(menu, 1, 3))
            {
                switch (menu)
                {
                    case 1:
                        addNewCategory(ownindex);
                        AddMenu(ownindex);
                        break;
                    case 2:
                        addSortsIntoExistingCategory(ownindex);
                        AddMenu(ownindex);
                        break;
                    case 3:
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nPlease select the menu between 1 and 3...Try again please...\n");
                AddMenu(ownindex);
                return;
            }
        }

        #region Add Menu Choice Methods
        static void addNewCategory(int ownindex)
        {
            //ilk once yeni kateqorinin adi istenilir
            string categoryname = CommonMethods.getString("\nNew Category name: ");

            //elave edilmis yeni kateqoriye sortlari da elave edirik
            string mealname = CommonMethods.getString("Meal name: ");
            float price = CommonMethods.getFloat("Price: ");

            //yekun olaraq butun melumatlari elave edilir
            Owner owner = (Owner)Storage.profiles[ownindex];
            owner.MealMenu.Add(new MealMenu(categoryname)); //meal menu elave edilir
            for (int i = 0; i < owner.MealMenu.Count; i++) //sort menyu elave edilir
            {
                if (owner.MealMenu[i].CategoryName == categoryname)
                {
                    owner.MealMenu[i].Sorts.Add(new Sort(mealname, price));
                    break;
                }
            }

            Console.WriteLine("\nNew menu added...\n");
        }

        static void addSortsIntoExistingCategory(int ownindex)
        {
            int row = 1;
            List<string> categories = new List<string>();

            //ilk once kateqori menyulari ekrana cap edilsin
            Owner owner = (Owner)Storage.profiles[ownindex];

            Console.WriteLine("\nAll categories...\n");
            for (int i = 0; i < owner.MealMenu.Count; i++)
            {
                Console.WriteLine($"{row}. {owner.MealMenu[i].CategoryName}");
                categories.Add(owner.MealMenu[i].CategoryName);
                row++;
            }

            //capa verilen kateqorilerden secilir
            int categoryindex = CommonMethods.getInteger("Please select the category above: ");
            string category = categories[categoryindex - 1];

            //category adina uygun sistemde menyu tapilir ve yeni sort elave edilir
            for (int i = 0; i < owner.MealMenu.Count; i++)
            {
                if (category == owner.MealMenu[i].CategoryName)
                {
                    //melumatlar elde edilib elave edilir
                    string mealname = CommonMethods.getString("\nPlease write the meal name: ");
                    float price = CommonMethods.getFloat("Please write the meal price: ");

                    owner.MealMenu[i].Sorts.Add(new Sort(mealname, price));
                    break;
                }
            }

            Console.WriteLine($"\nNew Meals added to {category}");
        }
        #endregion
        #endregion


        #region EditMenu
        static void EditMenu(int ownindex)
        {
            Console.WriteLine("\nEdit menu...\n");

            Console.WriteLine(
                "1. Edit category name" +
                "\n2. Edit meal name" +
                "\n3. Back to previous menu");
            int menu = CommonMethods.selectMenuAbove();

            if (CommonMethods.CheckMenuBetween(menu, 1, 3))
            {
                switch (menu)
                {
                    case 1:
                        editCategoryName(ownindex);
                        EditMenu(ownindex);
                        break;
                    case 2:
                        editMealNameAndPrice(ownindex);
                        EditMenu(ownindex);
                        break;
                    case 3:
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nPlease select the menu between 1 and 3...Try again please...\n");
                EditMenu(ownindex);
                return;
            }
        }

        #region Edit Menu Choice Methods
        static void editCategoryName(int ownindex)
        {
            int row = 1;
            string prevcategoryname = "";
            List<string> categories = new List<string>();

            //ilk once cari categoryleri gosterir
            Owner owner = (Owner)Storage.profiles[ownindex];
            for (int i = 0; i < owner.MealMenu.Count; i++)
            {
                Console.WriteLine($"{row}. {owner.MealMenu[i].CategoryName}");
                categories.Add(owner.MealMenu[i].CategoryName);
                row++;
            }

            //daha sonra kateqoriler arasindan biri secilir
            int categoryindex = CommonMethods.getInteger("Please select the category above: ");
            string category = categories[categoryindex - 1];

            //secilen kateqoriye deyisiklik edilir
            string newcategoryname = CommonMethods.getString("\nPlease write the new category name: ");
            for (int i = 0; i < owner.MealMenu.Count; i++)
            {
                if (category == owner.MealMenu[i].CategoryName)
                {
                    prevcategoryname = owner.MealMenu[i].CategoryName;
                    owner.MealMenu[i].CategoryName = newcategoryname;
                    break;
                }
            }

            Console.WriteLine($"\n{prevcategoryname} changed to {newcategoryname}\n");
        }

        static void editMealNameAndPrice(int ownindex)
        {
            int row = 1;
            string prevcategoryname = "";
            List<string> categories = new List<string>();
            List<string> sorts = new List<string>();

            //ilk once cari categoryleri gosterir
            Owner owner = (Owner)Storage.profiles[ownindex];
            for (int i = 0; i < owner.MealMenu.Count; i++)
            {
                Console.WriteLine($"{row}. {owner.MealMenu[i].CategoryName}");
                categories.Add(owner.MealMenu[i].CategoryName);
                row++;
            }

            //daha sonra kateqoriler arasindan biri secilir
            int categoryindex = CommonMethods.getInteger("Please select the category above: ");
            string category = categories[categoryindex - 1];

            // categoriye uygun gelen sortlar cap edilir
            row = 1;
            for (int i = 0; i < owner.MealMenu.Count; i++)
            {
                if (category == owner.MealMenu[i].CategoryName)
                {
                    for (int j = 0; j < owner.MealMenu[i].Sorts.Count; j++)
                    {
                        Console.WriteLine($"{row}. {owner.MealMenu[i].Sorts[j].MealName} - {owner.MealMenu[i].Sorts[j].Price}");
                        sorts.Add(owner.MealMenu[i].Sorts[j].MealName);
                        row++;
                    }
                }
            }

            //daha sonra sortlar arasindan biri secilir
            int sortindex = CommonMethods.getInteger("Please select the sort above: ");
            string mealname = sorts[sortindex - 1];

            //uygun olaraq yeni mealname ve price istenilir
            string newmealname = CommonMethods.getString("\nPlease write the new meal name: ");
            float newprice = CommonMethods.getFloat("\nPlease write the new price: ");
            string prevmealname = "";
            float prevprice = 0;
            for (int i = 0; i < owner.MealMenu.Count; i++)
            {
                if (category == owner.MealMenu[i].CategoryName)
                {
                    for (int j = 0; j < owner.MealMenu[i].Sorts.Count; j++)
                    {
                        if (mealname == owner.MealMenu[i].Sorts[j].MealName)
                        {
                            prevmealname = owner.MealMenu[i].Sorts[j].MealName;
                            prevprice = owner.MealMenu[i].Sorts[j].Price;

                            owner.MealMenu[i].Sorts[j].MealName = newmealname;
                            owner.MealMenu[i].Sorts[j].Price = newprice;
                        }
                    }
                }
            }

            Console.WriteLine($"{prevmealname} and {prevprice} changed to {newmealname} and {newprice}");
        }
        #endregion
        #endregion


        #region DeleteMenu
        static void DeleteMenu(int ownindex)
        {
            Console.WriteLine("\nDelete menu...\n");

            Console.WriteLine(
                "1. Delete category" +
                "\n2. Delete meal" +
                "\n3. Back to previous menu");
            int menu = CommonMethods.selectMenuAbove();

            if (CommonMethods.CheckMenuBetween(menu, 1, 3))
            {
                switch (menu)
                {
                    case 1:
                        deleteCategory(ownindex);
                        DeleteMenu(ownindex);
                        break;
                    case 2:
                        deleteSort(ownindex);
                        DeleteMenu(ownindex);
                        break;
                    case 3:
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nPlease select the menu between 1 and 3...Try again please...\n");
                DeleteMenu(ownindex);
                return;
            }
        }

        #region Edit Menu Choice Methods
        static void deleteCategory(int ownindex)
        {
            int row = 1;
            string deletedcategory = "";
            List<string> categories = new List<string>();

            //Kateqorileri ekrana cap edecek
            Owner owner = (Owner)Storage.profiles[ownindex];

            for (int i = 0; i < owner.MealMenu.Count; i++)
            {
                Console.WriteLine($"{row}. {owner.MealMenu[i].CategoryName}");
                categories.Add(owner.MealMenu[i].CategoryName);
                row++;
            }

            //cap edilen kateqoriler arasindan secim edilir
            int categoryiindex = CommonMethods.getInteger("Please select the category above: ");
            string category = categories[categoryiindex - 1];

            //daha sonra secilen katqori ownerin menyularindan silinir
            for (int i = 0; i < owner.MealMenu.Count; i++)
            {
                if (category == owner.MealMenu[i].CategoryName)
                {
                    deletedcategory = owner.MealMenu[i].CategoryName;
                    owner.MealMenu.RemoveAt(i);
                }
            }

            Console.WriteLine($"{deletedcategory} deleted from menus...");
        }

        static void deleteSort(int ownindex)
        {
            int row = 1;
            string deletedcategory = "";
            List<string> categories = new List<string>();
            List<string> mealnames = new List<string>();

            //Kateqorileri ekrana cap edecek
            Owner owner = (Owner)Storage.profiles[ownindex];

            for (int i = 0; i < owner.MealMenu.Count; i++)
            {
                Console.WriteLine($"{row}. {owner.MealMenu[i].CategoryName}");
                categories.Add(owner.MealMenu[i].CategoryName);
                row++;
            }

            //cap edilen kateqoriler arasindan secim edilir
            int categoryiindex = CommonMethods.getInteger("Please select the category above: ");
            string category = categories[categoryiindex - 1];

            //secilen kateqoriye uygun mealnameler ekrana cap edilir
            row = 1;
            for (int i = 0; i < owner.MealMenu.Count; i++)
            {
                if (category == owner.MealMenu[i].CategoryName)
                {
                    for (int j = 0; j < owner.MealMenu[i].Sorts.Count; j++)
                    {
                        Console.WriteLine($"{row}. {owner.MealMenu[i].Sorts[j].MealName}");
                        mealnames.Add(owner.MealMenu[i].Sorts[j].MealName);
                        row++;
                    }
                }
            }

            //cap edilen kateqoriler arasindan secim edilir
            int sortindex = CommonMethods.getInteger("Please select the category above: ");
            string mealname = mealnames[sortindex - 1];
            string prevmealname = "";

            //meal name sistemden tapilir ve silinir
            for (int i = 0; i < owner.MealMenu.Count; i++)
            {
                if (category == owner.MealMenu[i].CategoryName)
                {
                    for (int j = 0; j < owner.MealMenu[i].Sorts.Count; j++)
                    {
                        if (mealname == owner.MealMenu[i].Sorts[j].MealName)
                        {
                            prevmealname = owner.MealMenu[i].Sorts[j].MealName;
                            owner.MealMenu[i].Sorts.RemoveAt(j);
                        }
                    }
                }
            }

            Console.WriteLine($"\n{prevmealname} deleted from {category} category");
        }
        #endregion
        #endregion


        #region EditOtherInformations
        static void EditOtherInformations(int ownindex)
        {
            Console.WriteLine("\nEdit informations...\n");

            Console.WriteLine(
                "1. Edit login" +
                "\n2. Edit password" +
                "\n3. Edit fullname" +
                "\n4. Back to previous menu");
            int menu = CommonMethods.selectMenuAbove();

            if (CommonMethods.CheckMenuBetween(menu, 1, 4))
            {
                switch (menu)
                {
                    case 1:
                        editLogin(ownindex);
                        EditOtherInformations(ownindex);
                        break;
                    case 2:
                        editPassword(ownindex);
                        EditOtherInformations(ownindex);
                        break;
                    case 3:
                        editFullname(ownindex);
                        EditOtherInformations(ownindex);
                        break;
                    case 4:
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nPlease select the menu between 1 and 4...Try again please...\n");
                EditOtherInformations(ownindex);
                return;
            }
        }

        #region Edit Other Informations Methods
        static void editLogin(int ownindex)
        {
            //Cari login capa verilir
            Console.WriteLine($"Current login: {Storage.profiles[ownindex].Login}");

            //yeni login teleb edilir
            string prevlogin = Storage.profiles[ownindex].Login;
            string newlogin = CommonMethods.getString("Please write the new login: ");

            Storage.profiles[ownindex].Login = newlogin;

            Console.WriteLine($"\n{prevlogin} edited to {newlogin}");
        }
        static void editPassword(int ownindex)
        {
            //Cari login capa verilir
            Console.WriteLine($"Current password: {Storage.profiles[ownindex].Password}");

            //yeni login teleb edilir
            string prevpassword = Storage.profiles[ownindex].Password;
            string newpassword = CommonMethods.getString("Please write the new password: ");

            Storage.profiles[ownindex].Login = newpassword;

            Console.WriteLine($"\n{prevpassword} edited to {newpassword}");
        }
        static void editFullname(int ownindex)
        {
            //Cari login capa verilir
            Console.WriteLine($"Current fullname: {Storage.profiles[ownindex].Fullname}");

            //yeni login teleb edilir
            string prevfullname = Storage.profiles[ownindex].Fullname;
            string newfullname = CommonMethods.getString("Please write the new fullname: ");

            Storage.profiles[ownindex].Fullname = newfullname;

            Console.WriteLine($"\n{prevfullname} edited to {newfullname}");
        }
        #endregion
        #endregion

    }
}
