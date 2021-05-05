using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public class DevTeamsRepo
    {
        //This is our Repository class that will hold our directory (which will act as our database) and methods that will directly talk to our directory.

        private readonly List<Developer> _devDirectory = new List<Developer>();

        // CRUD Methods below

        public bool AddDevToDirectory(Developer newDev)
        {
            int startingCount = _devDirectory.Count;

            _devDirectory.Add(newDev);

            bool devAdded = (_devDirectory.Count > startingCount) ? true : false;
            return devAdded;
        }

        public List<Developer> GetDevs()
        {
            return _devDirectory;
        }

        public Developer GetDeveloperByName(string firstName, string lastName)
        {
            foreach (Developer dev in _devDirectory)
            {
                if (dev.FirstName.ToLower() == firstName.ToLower() && dev.LastName.ToLower() == lastName.ToLower())
                {
                    return dev;
                }
            }
            return null;
        }

        public bool UpdateExistingDeveloper(string oldDevFirstName, string oldDevLastName, Developer newDev)
        {
            Developer oldDev = GetDeveloperByName(oldDevFirstName, oldDevLastName);

            if (oldDev != null)
            {
                oldDev.FirstName = newDev.FirstName;
                oldDev.LastName = newDev.LastName;
                oldDev.ID = newDev.ID;
                oldDev.TeamAssignment = newDev.TeamAssignment;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteExistingDeveloper(string devFirstNameToDelete, string devLastNameToDelete)
        {
            Developer devToDelete = GetDeveloperByName(devFirstNameToDelete, devLastNameToDelete);
            if(devToDelete != null)
            {
                _devDirectory.Remove(devToDelete);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
