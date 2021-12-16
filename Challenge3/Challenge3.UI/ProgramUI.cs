using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge3.Repo;

namespace Challenge3.UI
{
    public class ProgramUI
    {
        BadgeRepo _badgeRepo = new BadgeRepo();

        internal void Run()
        {
            RunApplication();
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
                        AddBadge();
                        break;
                    case "2":
                        UpdateDoorAccess();
                        break;
                    case "3":
                        RemoveAllAccessFromBadge();
                        break;
                    case "4":
                        _badgeRepo.ShowAllBadges();
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void RemoveAllAccessFromBadge()
        {
            throw new NotImplementedException();
        }

        private void UpdateDoorAccess()
        {
            throw new NotImplementedException();
        }

        public void Menu()
        {
            Console.WriteLine("Welcome To Komodo's Badge Manager!\n" +
                "1. Add A Badge\n" +
                "2. Add/Remove Door Access\n" +
                "3. Remove All Door Access from Badge\n" +
                "4. Show all badges\n" +
                "5. Exit Application");
        }

        public void AddBadge()
        {
            Badge badgeToBeAdded = new Badge();
            List<string> doorList = new List<string>();

            Console.WriteLine("What is the badge number of the badge you are looking to add?");
            badgeToBeAdded.BadgeID = int.Parse(Console.ReadLine());

            bool addingDoors = true;
            while (addingDoors)
            {
                Console.WriteLine("What is a single door that your badge needs access too?");
                string userInputDoor = Console.ReadLine();

                doorList.Add(userInputDoor);
                Console.WriteLine("Is there any other doors it needs access to? y/n");
                string userInputYesNo = Console.ReadLine();

                if (userInputYesNo == "y")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine($"Thank you for adding Badge #{badgeToBeAdded.BadgeID} to our database!");
                    Console.ReadKey();
                    addingDoors = false;
                }
            }
            badgeToBeAdded.DoorNames = doorList;
            _badgeRepo.AddBadge(badgeToBeAdded);

            Console.WriteLine();
        }
    }
}
