using PostalService.Models.ShippingStrategy;
using PostalService.Models.WeightStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models
{
    public class UserInput
    {
        public string ReadString(string question)
        {
            string userInputString = "";

            Console.WriteLine(question);
            userInputString = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(userInputString))
            {
                Console.WriteLine(question);
                userInputString = Console.ReadLine();
            }


            return userInputString;

        }

        public decimal ReadDecimal(string question)
        {
            string userInputString = "";
            Console.WriteLine(question);

            userInputString = Console.ReadLine();
            decimal userInputDecimal;

            while (!decimal.TryParse(userInputString, out userInputDecimal))
            {
                Console.WriteLine("Fel format: " + question);
                userInputString = Console.ReadLine();
            }

            return userInputDecimal;

        }

        //public string ReadShippingType(string question)
        //{

        //    while (true)
        //    {
        //        Console.WriteLine("Välj Fraktyp:");
        //        Console.WriteLine("1. Standardfrakt (3dagar):");
        //        Console.WriteLine("2. Expressfrakt (2 dagar):");
        //        Console.WriteLine("3. Ekonomifrakt (7dagar):");

        //        Console.WriteLine("Gör ett val mellan 1-3");
        //        string userInput = Console.ReadLine();

        //        return userInput;

        //    }
        //}

        
    }
}
