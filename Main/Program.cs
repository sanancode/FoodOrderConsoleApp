using FoodOrderConsoleApp.Management;
using FoodOrderConsoleApp.Models;
using FoodOrderConsoleApp.Utility;

namespace FoodOrderConsoleApp.Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tWelcome to Food Order Console Application\n");
            Storage.LoadAllAddressesToSystem();
            RegistrationAndEnteringMenu();
            Console.WriteLine("\n\tprogram ended...\n");
        }

        public static void RegistrationAndEnteringMenu()
        {
            MenuUtil.Menu1();
            int menu = CommonMethods.selectMenuAbove();

            if (CommonMethods.CheckMenuBetween(menu, 1, 6))
            {
                switch (menu)
                {
                    case 1: //Register as a Customer
                        RegisterManagement.RegisterCustomer();
                        RegistrationAndEnteringMenu();
                        break;
                    case 2: //Register as an Owner
                        RegisterManagement.RegisterOwner();
                        RegistrationAndEnteringMenu();
                        break;
                    case 3: //Already have an account?

                        if (CommonMethods.checkExistProfiles()) //eger sistemde profil varsa
                        {
                            int profileindex = LoginManagement.LoginTheSystem(); //daxil olanin indeksini getirir

                            if (Storage.profiles[profileindex].Type == "C") //hansi profil daxil olub onu teyin edir
                            {
                                CustomerOperationManagement.GoSelectedMenuForCustomer(profileindex);
                            }
                            else
                            {
                                OwnerOperationManagement.GoSelectedMenuForOwner(profileindex);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nThere is not any registered profiles in the system");
                        }

                        RegistrationAndEnteringMenu();
                        break;

                    case 4: //Show all customers
                        ShowAll.ShowAllRegisteredCustomers();
                        RegistrationAndEnteringMenu();
                        break;
                    case 5: //Show all owners
                        ShowAll.ShowAllRegisteredOwners();
                        RegistrationAndEnteringMenu();
                        break;
                    case 6: //Enter as an admin
                        AdminPanel.LoginAdmin();
                        RegistrationAndEnteringMenu();
                        break;
                    case 7:
                        Console.WriteLine("\nExiting the system...");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nPlease select the menu between 1 and 6...Try again...\n");
                RegistrationAndEnteringMenu();
                return;
            }
        }
    }
}