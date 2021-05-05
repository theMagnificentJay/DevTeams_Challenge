using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public enum TeamAssignment { FrontEnd = 1, BackEnd, Testing}
    public class Developer
    {
        //This is our POCO class. It will define our properties and constructors of our Developer objects.
        //Developer objects should have the following properties
        //ID
        //FirstName
        //LastName
        //a bool that shows whether they have access to the online learning tool Pluralsight.
        //TeamAssignment - use the enum declared above this class
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TeamAssignment TeamAssignment { get; set; }

        public bool HasPluralsight
        {
            get
            {
                if (HasPluralsight == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Developer() { }
        public Developer(int id, string firstName, string lastName, TeamAssignment teamAssignment)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            TeamAssignment = teamAssignment;
        }
    }
}
