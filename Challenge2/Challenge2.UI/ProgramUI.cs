using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge2.Repo;
using static Challenge2.Repo.Claim;

namespace Challenge2.UI
{
    class ProgramUI
    {
        private readonly ClaimRepo _claimRepo = new ClaimRepo();

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
                        ViewAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        CreateClaim();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void TakeCareOfNextClaim()
        {
            Queue<Claim> nextClaim = _claimRepo.GetClaims();
            DisplayClaimInfo(nextClaim.Peek());
             
            Console.ReadKey();

            Console.WriteLine("Is this the claim that you wish to take care of?\n" +
                "1. Yes\n" +
                "2. No");

            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                _claimRepo.DequeueClaim();
                Console.WriteLine("The claim has been removed from our queue! Thank you!");
            }
            else
            {
                Console.WriteLine("The claim has failed to be removed from our queue! Please try again!");
            }
            Console.ReadLine();
        }

        public void Menu()
        {
            Console.WriteLine("Welcome to Komodo Insurance Claim Manager! What can we help you with today?\n" +
                "1. See All Claims\n" +
                "2. Take Care of Next Claim\n" +
                "3. Enter a new Claim\n" +
                "4. Exit Application");
        }

        public void ViewAllClaims()
        {
            Console.Clear();
            Queue<Claim> listOfAllClaims = _claimRepo.GetClaims();

            foreach (var claim in listOfAllClaims)
            {
                DisplayClaimInfo(claim);
            }
            Console.ReadLine();
        }

        private void DisplayClaimInfo(Claim claim)
        {
            Console.WriteLine($"{claim.ClaimId}\n" +
                $"{claim.TypeOfClaim}\n" +
                $"{claim.Description}\n" +
                $"{claim.ClaimAmount}\n" +
                $"{claim.DateOfIncident}\n" +
                $"{claim.DateOfClaim}\n" +
                $"{claim.IsValid}");
            Console.WriteLine("*******************************");
        }

        private void CreateClaim()
        {
            Console.Clear();

            DateTime todaysDate = DateTime.Today;

            Console.WriteLine("What was the ID of the claim you're entering into the system?");
            int userInputClaimId = int.Parse(Console.ReadLine());

            Console.WriteLine("What type of claim are you submitting today?\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");

            int userInputClaimType = int.Parse(Console.ReadLine());
            ClaimType claimType = (ClaimType)(userInputClaimType);

            Console.WriteLine("Enter a short description of the claim.");
            string userInputDescription = Console.ReadLine();

            Console.WriteLine("How much is the claim amount?");
            decimal userInputAmount = Decimal.Parse(Console.ReadLine());

            Console.WriteLine("What was the date the incident occured? Please enter exactly as shown in example. (ex.. Jan 12, 2009)");
            DateTime inputDate = DateTime.Parse(Console.ReadLine());

            Claim claimToBeAdded = new Claim(userInputClaimId, claimType, userInputDescription, userInputAmount, inputDate, todaysDate);

            Console.WriteLine("Is this claim still valid?\n" +
                "1. Yes\n" +
                "2. No");
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                claimToBeAdded.IsValid = true;
                bool isSuccessful = _claimRepo.CreateClaim(claimToBeAdded);
                if (isSuccessful)
                {
                    Console.WriteLine($"Your Claim of Claim Id: {claimToBeAdded.ClaimId} has been entered into the database! Thank you!");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your claim couldn't be added to the database. Make sure you have enetered all information correctly\n" +
                        "and try again. Thank you!");
                    Console.ReadLine();
                }
            }
            else
            {
                claimToBeAdded.IsValid = false;
            }

            
        }
    }
}
