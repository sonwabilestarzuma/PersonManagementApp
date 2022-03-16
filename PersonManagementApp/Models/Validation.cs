using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PersonManagementApp.Models
{
    public static class Validation
    {
        const string key_empty = "empty";
        const string key_FirstName_format = "wrong_FirstName_format";
        const string key_LastName_format = "wrong_LastName_format";
        const string key_number_format = "wrong_number_format";
        const string key_number_value = "wrong_number_value";
        public static void displayMessage(string value)
        {
            switch (value)
            {
                case "empty":
                    Console.WriteLine("You have to insert value.");
                    break;
                case "wrong_FirstName_format":
                    Console.WriteLine("First Name is not in an appropriate format.");
                    break;
                case "wrong_LastName_format":
                    Console.WriteLine("Last Name is not in an appropriate format.");
                    break;
                case "wrong_number_format":
                    Console.WriteLine("Number is not in an appropriate format.");
                    break;
                case "wrong_number_value":
                    Console.WriteLine("Number is not in the correct range.");
                    break;
            }
        }
        public static bool validateFirstName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                displayMessage(key_empty);
                return false;
            }
            else if (!Regex.IsMatch(value, @"^[a-zA-Z]+$"))
            {
                displayMessage(key_FirstName_format);
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool validateLastName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                displayMessage(key_empty);
                return false;
            }
            else if (!Regex.IsMatch(value, @"^[a-zA-Z]+$"))
            {
                displayMessage(key_LastName_format);
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool validateGPA(string value)
        {
            float gpa;
            if (string.IsNullOrEmpty(value))
            {
                displayMessage(key_empty);
                return false;
            }
            else if (!float.TryParse(value, out gpa))
            {
                displayMessage(key_number_format);
                return false;
            }
            else if (gpa < 1 || gpa > 5)
            {
                displayMessage(key_number_value);
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}