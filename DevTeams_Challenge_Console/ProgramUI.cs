using DevTeams_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Console
{
    public class ProgramUI
    {
        //This class will be how we interact with our user through the console. When we need to access our data, we will call methods from our Repo class.

        private DevTeamsRepo _repo = new DevTeamsRepo();

        public void Run()
        {
            SeedDevList();
            Menu();
        }

        private void Menu()
        {
            //Start with the main menu here
            bool keepRunning = true;
            while (keepRunning == true)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Developer\n" +
                    "2. View All Developers\n" +
                    "3. Update Existing Developer\n" +
                    "4. Delete Exisiting Developer\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "1":
                        // CreateNewDev
                        CreateNewDev();
                        break;
                    case "2":
                        // ViewAllDeveloper
                        DisplayAllDevs();
                        break;
                    case "3":
                        // UpdateExistingDeveloper
                        UpdateDev();
                        break;
                    case "4":
                        // DeleteExisitingDeveloper
                        DeleteDev();
                        break;
                    case "5":
                        // Exit
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        break;
                }
                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateNewDev()
        {
            Console.Clear();
            Developer newDev = new Developer();

            // Set FirstName
            Console.WriteLine("What is the first name of the developer you are wanting to add?");
            newDev.FirstName = Console.ReadLine();

            // Set LastName
            Console.WriteLine("What is the last name of the developer you are wanting to add?");
            newDev.LastName = Console.ReadLine();

            // Set ID
            Console.WriteLine("What is the ID number of the developer you are wanting to add? [number input only]");
            newDev.ID = Convert.ToInt32(Console.ReadLine());

            // Set TeamAssignment
            Console.WriteLine("What is this developers team assignment?\n" +
                "1. FrontEnd\n" +
                "2. BackEnd\n" +
                "3. Testing");
            newDev.TeamAssignment = (TeamAssignment)Convert.ToInt32(Console.ReadLine());

            bool wasAddedCorrectly = _repo.AddDevToDirectory(newDev);
            if (wasAddedCorrectly)
            {
                Console.WriteLine("Developer added successfully.");
            }
            else
            {
                Console.WriteLine("Could not add developer.");
            }
        }

        private void DisplayAllDevs()
        {
            Console.Clear();
            List<Developer> allDevs = _repo.GetDevs();
            foreach (Developer dev in allDevs)
            {
                Console.WriteLine($"{dev.ID} {dev.FirstName} {dev.LastName} {dev.TeamAssignment}\n");
            }
        }

        private void UpdateDev()
        {
            Console.Clear();
            DisplayAllDevs();
            Console.WriteLine("Enter the first name of the developer you would like to update.");

            string oldDevFirstName = Console.ReadLine();

            Console.WriteLine("Enter the last name of the developer you would like to update.");

            string oldDevLastName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"You are updating information for {oldDevFirstName} {oldDevLastName}.\n");

            Developer newDev = new Developer();

            // Set FirstName
            Console.WriteLine("What is the first name of the developer you are wanting to add?");
            newDev.FirstName = Console.ReadLine();

            // Set LastName
            Console.WriteLine("What is the last name of the developer you are wanting to add?");
            newDev.LastName = Console.ReadLine();

            // Set ID
            Console.WriteLine("What is the ID number of the developer you are wanting to add? [number input only]");
            newDev.ID = Convert.ToInt32(Console.ReadLine());

            // Set TeamAssignment
            Console.WriteLine("What is this developers team assignment?\n" +
                "1. FrontEnd\n" +
                "2. BackEnd\n" +
                "3. Testing");
            newDev.TeamAssignment = (TeamAssignment)Convert.ToInt32(Console.ReadLine());

            bool wasUpdated = _repo.UpdateExistingDeveloper(oldDevFirstName, oldDevLastName, newDev);
            if(wasUpdated == true)
            {
                Console.WriteLine("The developer was updated successfully.");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again. CatchErr.");
            }
        }

        private void DeleteDev()
        {
            Console.Clear();
            DisplayAllDevs();

            Console.WriteLine("Enter the first name of the developer you'd like to delete.");
            string devToDeleteFirstName = Console.ReadLine();

            Console.WriteLine("Enter the last name of the developer you'd like to delete.");

            string devToDeleteLastName = Console.ReadLine();

            bool devToDelete = _repo.DeleteExistingDeveloper(devToDeleteFirstName, devToDeleteLastName);

            if (devToDelete)
            {
                Console.WriteLine("Developer was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Developer could not be deleted. CatchErr.");
            }
        }

        private void SeedDevList()
        {
            Developer john = new Developer(01, "John", "Doe", TeamAssignment.FrontEnd);
            Developer joe = new Developer(02, "Joe", "Namely", TeamAssignment.BackEnd);
            Developer jane = new Developer(03, "Jane", "Dawson", TeamAssignment.Testing);

            _repo.AddDevToDirectory(john);
            _repo.AddDevToDirectory(joe);
            _repo.AddDevToDirectory(jane);
        }
    }
}
