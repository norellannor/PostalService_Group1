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
            Console.WriteLine(question);
            string userInputString = Console.ReadLine() ?? "";

            while (string.IsNullOrWhiteSpace(userInputString))
            {
                Console.WriteLine("Fältet får inte vara tomt.");
                Console.Write(question);
                userInputString = Console.ReadLine() ?? "";
            }

            return userInputString.Trim();

        }


        public string ReadName(string question)
        {
            while (true)
            {
                string name = ReadString(question);

                bool onlyLettersAndSpaces = name.All(c =>
                    char.IsLetter(c) || c == ' ' || c == '-');

                if (onlyLettersAndSpaces && name.Length <= 18)
                {
                    return name;
                }
                
                Console.WriteLine(
                    "Namnet får endast innehålla bokstäver, mellanslag och bindestreck, och får vara högst 18 tecken.");
                
            }
        }

        public string ReadCity(string question)
        {
            while (true)
            {
                string city = ReadString(question);
                
                bool onlyLettersAndSpaces = city.All(c =>
                    char.IsLetter(c) || c == ' ' || c == '-');

                if (onlyLettersAndSpaces && city.Length <= 40)
                {
                    return city;
                }

                Console.WriteLine(
                    "orten får endast innehålla bokstäver, mellanslag och bindestreck, och får vara högst 40 tecken.");
            }
        }

        public string ReadPostalCode(string question)
        {
            while (true)
            {
                string postalCode = ReadString(question);

                if (postalCode.Length == 5 &&
                    postalCode.All(char.IsDigit))
                {
                    return postalCode;
                }
                
                Console.WriteLine("Postnummer måste bestå av exakt 5 siffror.");
            }
        }

        public string ReadPhoneNumber(string question)
        {
            while (true)
            {
                Console.WriteLine(question);
                Console.WriteLine("Frivilligt - tryck Enter för att hoppa över.");

                string phoneNumber = Console.ReadLine()?.Trim() ?? "";
                
                // Telefonnummret är frivilligt.
                if (string.IsNullOrEmpty(phoneNumber))
                {
                    return "";
                }

                bool validCharacters = phoneNumber.All(c =>
                    char.IsDigit(c) || c == '+');

                bool validLength = phoneNumber.Length >= 9
                                   && phoneNumber.Length <= 13;

                bool validPlus = phoneNumber.Count(c => c == '+') <= 1 &&
                                 (!phoneNumber.Contains('+') ||
                                  phoneNumber.StartsWith("+"));

                bool hasDigits = phoneNumber.Any(char.IsDigit);
                
                if (validCharacters && validLength && validPlus  && hasDigits)
                { 
                    return phoneNumber;
                }

                Console.WriteLine(
                    "Ogiltigt telefonnummer. Ange 9-13 siffror med eventuellt + först, eller tryck Enter för att hoppa över.");
                
            }
        }

        public string ReadTextWithMaxLength(string question, int maxLength)
        {
            while (true)
            {
                string text = ReadString(question);

                if (text.Length <= maxLength)
                {
                    return text;
                }
                Console.WriteLine($"Texten får vara högst {maxLength} tecken.");
            }
        }
        

        public decimal ReadDecimal(string question)
        {

            while (true)
            {
                string userInputString = ReadString(question);
                
                if (decimal.TryParse(userInputString, out decimal weight)
                     && weight > 0)
                    {
                        return weight;
                    }

                Console.WriteLine("Felaktig vikt. Ange ett tal större än 0, exempelvis 2,5.");
            }

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
