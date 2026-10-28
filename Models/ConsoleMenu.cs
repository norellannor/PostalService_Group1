using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostalService.Models.PostalCheckPoints;

namespace PostalService.Models
{
    public class ConsoleMenu
    {
        private readonly ParcelRegistry registry = new ParcelRegistry();

        public void Menu()
        {
            bool loopMenu = true;
            //var ombudLudvika = new ServicePoint { Location = "Ombud Ludvika", Destination = 1 };
            Parcel parcel;

            ParcelCreator createNewParcel = new ParcelCreator();
            while (loopMenu)
            {

                Console.WriteLine("*******************************");
                Console.WriteLine("   Paketleverans och spårning  ");
                Console.WriteLine("*******************************");
                Console.WriteLine("1. Registrera paket");
                Console.WriteLine("2. Spåra paket med försändelse-id");
                Console.WriteLine("3. Logga in som administratör");
                Console.WriteLine("4. Avsluta");
                Console.Write("Gör ett val mellan 1-4: ");

                string userInputFromMenu = Console.ReadLine();
                Console.Clear();

                switch (userInputFromMenu)
                {
                    case "1":
                        parcel = createNewParcel.ConfirmCreatedParcel();
                        int id = registry.AddParcel(parcel);
                        Console.WriteLine($"Ditt försändelse-id är {id}.");
                        break;

                    case "2":
                        //Lägg in metod från ParcelRegistry
                        //Console.WriteLine("Du har valt 2");

                        Console.WriteLine("Sök på ett paket");
                        int parcelSearch = Int32.Parse(Console.ReadLine());
                        registry.FindParcelById(parcelSearch);
                        Console.WriteLine(registry.FindParcelById(parcelSearch));

                        loopMenu = false;
                        EscapeToMenu();
                        break;

                    case "3":
                        //Skapa klass för inlogg administratör som kan spåra paket och få ut mer information än kunden. 
                        //i klassen kan man kalla på metod från ParcelRegistry som skriver ut alla paket dictionary. 
                        ConsoleMenuAdministrator admin = new ConsoleMenuAdministrator(registry);
                        admin.MenuForAdministrator();

                        break;
                    case "4":
                        //ombudLudvika.ViewServicePointOutgoingParcels();
                        break;
                    case "5":
                        Console.WriteLine("*************************");
                        Console.WriteLine("*                       *");
                        Console.WriteLine("*  Programmet avslutas  *");
                        Console.WriteLine("*                       *");
                        Console.WriteLine("*************************");
                        Environment.Exit(0);
                        break;




                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Gör ett val mellan 1-4");
                        Console.ResetColor();
                        break;
                }
            }
        }

        public void EscapeToMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
