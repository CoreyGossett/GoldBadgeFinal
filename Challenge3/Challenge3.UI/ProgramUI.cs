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
                        DeleteAllAccessUpdateDoor();
                        break;
                    case "3":
                        ShowAllBadges();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void DeleteAllAccessUpdateDoor()
        {

            bool updatingAccess = true;

            while (updatingAccess)
            {
                Console.Clear();
                Console.WriteLine("What is the ID of the badge in which you are wishing to remove all access? Press 0 to see list of all Badges!");
                int badgeNumber = int.Parse(Console.ReadLine());


                if (badgeNumber == 0)
                {
                    ShowAllBadges();
                    continue;
                }
                else
                {
                    
                    Badge badge = _badgeRepo.GetBadgeById(badgeNumber);
                    badge.DoorNames = null;
                    Console.WriteLine($"Thank you! All doors have been removed from Badge#{badge.BadgeID}'s access. You will have to add more doors\n" +
                        $"because a badge has to have at least one access point.");
                    Console.ReadLine();

                    List<string> newDoorList = new List<string>();

                    bool addingDoors = true;
                    while (addingDoors)
                    {
                        Console.Clear();
                        Console.WriteLine($"What door would you like Badge#:{badge.BadgeID} to have access to?");
                        string userInputDoor = Console.ReadLine();

                        newDoorList.Add(userInputDoor);

                        Console.WriteLine("Is there any other doors it needs access to? y/n");
                        string yesOrNo = Console.ReadLine();
                        if (yesOrNo == "y")
                        {
                            continue;
                        }
                        else
                        {
                            badge.DoorNames = newDoorList;
                            break;
                        }

                    }

                    _badgeRepo.RemoveBadgeFromDictionary(badgeNumber);
                    _badgeRepo.AddBadge(badge);
                    Console.WriteLine($"Thank you for updating Badge#:{badge.BadgeID}'s door access!");
                    Console.ReadLine();
                    updatingAccess = false;
                }
            }
        }

        public void Menu()
        {
            Console.WriteLine("Welcome To Komodo's Badge Manager!\n" +
                "1. Add A Badge\n" +
                "2. Delete All and Update Door Access\n" +
                "3. Show all badges\n" +
                "4. Exit Application");
        }

        public void AddBadge()
        {
            Badge badgeToBeAdded = new Badge();
            List<string> doorList = new List<string>();
            Console.Clear();

            Console.WriteLine("What is the badge number of the badge you are looking to add?");
            badgeToBeAdded.BadgeID = int.Parse(Console.ReadLine());

            bool addingDoors = true;
            while (addingDoors)
            {
                Console.Clear();
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

        public void ShowAllBadges()
        {
            foreach (KeyValuePair<int, List<string>> badge in _badgeRepo._badgeDict)
            {
                Console.WriteLine("Badge #: {0}, Door Access: {1}",
                    badge.Key, string.Join(", ", badge.Value));
                Console.WriteLine("**********************************");
            }
            Console.ReadLine();
        }
    }
}
