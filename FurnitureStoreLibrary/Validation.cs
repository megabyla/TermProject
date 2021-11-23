using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FurnitureStoreLibrary
{
    public class Validation
    {
        public bool CheckRegistration(string firstName, string lastName, string phoneNumber)
        {
            Regex regex = new Regex("[^A-Za-z]");
            Regex numberRegex = new Regex("^[^0-9]+$");
            if (firstName == "" || regex.IsMatch(firstName) == true)
            {
                return false;
            }
            else if (lastName == "" || regex.IsMatch(lastName) == true)
            {
                return false;
            }
            else if (phoneNumber == "" || numberRegex.IsMatch(phoneNumber) == true)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}
