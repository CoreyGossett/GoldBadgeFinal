using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge1.Repo;

namespace Challenge1.UI
{
    class ProgramUI
    {
        private readonly MenuRepo _menuMethods = new MenuRepo();
        private readonly IngredientRepo _ingredientRepo = new IngredientRepo();

        internal void Run()
        {
            RunApplication();
        }

        public void Menu()
        {
            Console.WriteLine("Welcome to the Komodo Cafe Menu Manager!\n" +
                "1. Add Menu Item\n" +
                "2. Delete Menu Item\n" +
                "3. See All Menu Items\n" +
                "4. Exit Application");
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Menu();
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddMenuItem();
                        break;
                    case "2":
                        DeleteMenuItem();
                        break;
                    case "3":
                        ViewAllMenuItems();
                        break;
                }
            }
        }

        private void DeleteMenuItem()
        {
            bool isRemovingItem = true;

            while (isRemovingItem)
            {
                Console.Clear();
                Console.WriteLine("Enter the Meal Number of the Menu Item you wish to remove! Press 0 to see all menu items!");
                int userInput = int.Parse(Console.ReadLine());

                if (userInput == 0)
                {
                    ViewAllMenuItems();
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    Menu item = _menuMethods.GetMenuItemByMealNumber(userInput);
                    DisplayMenuItems(item);
                    Console.WriteLine("Is this the Menu Item you wish to remove?\n" +
                        "1. Yes\n" +
                        "2. No");
                    string yesOrNo = Console.ReadLine();
                    if (yesOrNo == "1")
                    {
                        _menuMethods.DeleteMenuItem(item);
                        Console.WriteLine($"Thank you for removing {item.MealName}!");
                        Console.ReadKey();
                        isRemovingItem = false;
                    }
                }
            }
        }

        public void AddMenuItem()
        {
            
            Console.Clear();

            Console.WriteLine("Please input the name of your new meal!");
            string userInputMealName = Console.ReadLine();

            Console.WriteLine("Please input the number you would like to correspond with this meal!");
            int userInputMealNumber = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please enter a short meal description!");
            string userInputMealDescription = Console.ReadLine();

            Console.WriteLine("Please enter the ingredients needed for this menu item!");
            string userInputMealIngredients = Console.ReadLine();

            Console.WriteLine("What is the price of this particular Menu Item?");
            decimal userInputMealPrice = Decimal.Parse(Console.ReadLine());

            Menu newItem = new Menu(userInputMealNumber, userInputMealName, userInputMealDescription, userInputMealPrice);

            bool isSuccessful = _menuMethods.AddMenuItem(newItem);
            if (isSuccessful)
            {
                Console.WriteLine($"{newItem.MealName} was added to our database with a meal number of {newItem.MealNumber}. Thank you!");
            }
            else
            {
                Console.WriteLine($"{newItem.MealName} couldn't be added to our database. Sorry!");
            }
            Console.WriteLine("Press enter to go back to the main menu!");
            Console.ReadLine();
            
        }

        private void ViewAllMenuItems()
        {
            Console.Clear();
            List<Menu> listOfAllMenuItems = _menuMethods.ReturnMenuItems();

            foreach (var menuItem in listOfAllMenuItems)
            {
                DisplayMenuItems(menuItem);
            }
        }

        private void DisplayMenuItems(Menu menuItem)
        {
            Console.WriteLine($"Menu Item Name: {menuItem.MealName}");
            Console.WriteLine($"Menu Item Number: {menuItem.MealNumber}");
            Console.WriteLine($"Menu Item Description: {menuItem.MealDescription}");
            Console.WriteLine($"Menu Item Name: {menuItem.Price}");
            Console.WriteLine("****************************************************");
        }

    }
}
