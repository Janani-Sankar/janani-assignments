using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName;
            string lastName;
            DateTime birthdate;
            string addressLine1;
            string addressLine2;
            string city;
            string stateProvidence;
            string zipPostal;
            string country;
            bool isStudent; // True/False variable that will establish Student/Teacher relationship


            // Use assignment statements to assign values
            firstName = "Janani";
            lastName = "Sankar";
            birthdate = new DateTime(1982, 08, 05);
            addressLine1 = "1032 Main St";
            addressLine2 = null;
            city = "Seattle";
            stateProvidence = "washington";
            zipPostal = "98004";
            country = "United States";
            isStudent = true;

            string isThisAStudent; // This will add a Yes/No value based on boolean logic
            if (isStudent)
            {
                isThisAStudent = "Yes";
            }
            else
            {
                isThisAStudent = "No";
            }


            // Use the Console.WriteLine() method to output the values to the console window
            Console.WriteLine("First Name: " + firstName);
            Console.WriteLine("First Name: " + lastName);
            Console.WriteLine("Birthdate: " + birthdate);
            Console.WriteLine("Address 1: " + addressLine1);
            Console.WriteLine("Address 2: " + addressLine2);
            Console.WriteLine("City: " + city);
            Console.WriteLine("State/Providence: " + stateProvidence);
            Console.WriteLine("Zip/Postal: " + zipPostal);
            Console.WriteLine("Country: " + country);
            Console.WriteLine("Is this a student?: " + isThisAStudent);
            Console.WriteLine("Input Firstname");
            Console.ReadLine();
            Console.WriteLine("input last name");
            Console.ReadLine();
            Console.WriteLine("input date of birth");
            Console.ReadLine();
            Console.WriteLine("input addressline1");
            Console.ReadLine();
            Console.WriteLine("input address line 2");
            Console.ReadLine();
        }
    }
}
