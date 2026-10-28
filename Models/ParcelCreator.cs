using PostalService.Models.ShippingStrategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostalService.Models
{
    public class ParcelCreator
    {
        //Metod för att Skapa paketet

        /*Metoden validerar de inputs som kommer från ex.
        RegisterParcel (där kunden får registrera sitt paket, det är här bara outputs och inputs.
        ParcelCreator: bestämmer vilka frågor som ska ställas. Skapar Address, Customer och fraktstrategin, och till sist Parcel.*/

       
        private UserInput userInput = new UserInput();

        public Parcel CreateParcel()
        {
            Customer sender = CreateCustomer("avsändaren");
            Customer receiver = CreateCustomer("mottagaren");
            decimal weight = userInput.ReadDecimal("Ange paketets vikt i kg (t.ex. 2,5):");
            IShippingStrategy shipping = ChooseShippingStrategy();

            return new Parcel(weight, sender, receiver, shipping);
        }

        private Customer CreateCustomer(string role)
        {
            string name = userInput.ReadString($"Namn på {role}:");
            string phoneNumber = userInput.ReadString($"Telefonnummer på {role}:");
            string streetName = userInput.ReadString($"Gatuadress för {role}:");
            string postalCode = userInput.ReadString($"Postnummer för {role}:");
            string city = userInput.ReadString($"Ort för {role}:");

            Address address = new Address(streetName, postalCode, city);
            return new Customer(name, address);
        }

        
        private IShippingStrategy ChooseShippingStrategy()
        {
            while (true)
            {
                Console.WriteLine("Välj frakt:");
                Console.WriteLine("1. Express(2 dagar)");
                Console.WriteLine("2. Standard (3 dagar)");
                Console.WriteLine("3. Ekonomi (7 dagar)");

                string choice = userInput.ReadString("Ditt val:");

                switch (choice)
                {
                    case "1":
                        return new ExpressShipping();

                    case "2":
                        return new StandardShipping();

                    case "3":
                        return new EconomyShipping();

                    default:
                        Console.WriteLine("Ogiltigt val, välj 1, 2 eller 3.");
                        break;
                }
            }
        }

        public Parcel ConfirmCreatedParcel()
        {
            Parcel parcel = CreateParcel();

            while (true)
            {
                Console.WriteLine(parcel);
                Console.WriteLine("Stämmer infon");
                Console.WriteLine("1.Ja");
                Console.WriteLine("2.Nej");

                string choice = userInput.ReadString("Ditt val:");

                switch (choice)
                {
                    case "1":
                        return parcel;
                    case "2":
                        Console.WriteLine("Skriv i uppgifterna igen");
                        parcel = CreateParcel();
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val");
                        break;

                }
            }
        }
    }
}
