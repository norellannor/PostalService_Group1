using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostalService.Models.PostalCheckPoints;
using PostalService.Models;
using System.Security.Cryptography.X509Certificates;



namespace PostalService.Models
{
    public class ConsoleMenu
    {
        private readonly ParcelRegistry registry = new ParcelRegistry();
        private readonly ConsoleMenuAdministrator admin;

        public ConsoleMenu()
        {
            registry = new ParcelRegistry();
            admin = new ConsoleMenuAdministrator(registry);
        }



        public void Menu()
        {
            bool loopMenu = true;
            
            Parcel parcel;

            ParcelCreator createNewParcel = new ParcelCreator();
            while (loopMenu)
            {

                Console.WriteLine("========================================");
                Console.WriteLine("             POSTAL SERVICE" );
                Console.WriteLine("========================================");
                Console.WriteLine("1. Registrera paket");
                Console.WriteLine("2. Spåra paket med försändelse-ID");
                Console.WriteLine("3. Logga in som administratör");
                Console.WriteLine("4. Avsluta");
                Console.WriteLine("========================================");
                Console.Write("Välj ett alternativ: ");

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
                        while (true)
                        {
                            //metod för att spåra paket 
                            Console.WriteLine("Sök på ett paket");
                            Console.WriteLine("Ange försändelse-ID: ");

                            if (!int.TryParse(Console.ReadLine(), out int parcelSearch))
                            {
                                Console.Clear();
                                Console.WriteLine("Försändelse-ID kan bara vara siffror.");
                                continue;
                            }
                            Parcel? foundparcel = registry.FindParcelById(parcelSearch);
                            if (foundparcel == null)
                            {
                                continue;
                            }
                            Console.WriteLine(foundparcel);

                            EscapeToMenu();
                            break;
                        }

                        break;
                    
                    case "3":
                        //Skapa klass för inlogg administratör som kan spåra paket och få ut mer information än kunden. 
                        //i klassen kan man kalla på metod från ParcelRegistry som skriver ut alla paket dictionary. 
                        
                        //admin.MenuForAdministrator();
                        admin.GetConsoleAdimistratorMenu();

                        break;
                    case "4":
                        //ombudLudvika.ViewServicePointOutgoingParcels();
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
