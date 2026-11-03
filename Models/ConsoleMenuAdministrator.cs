using Microsoft.Win32;
using PostalService.Models.PostalCheckPoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models
{
    public class ConsoleMenuAdministrator

    {
        private readonly ParcelRegistry registry;
        private readonly ServicePoint ombudA;
        private readonly ServicePoint ombudB;
        private static ParcelStation stationA = new ParcelStation("Station A");
        private static ParcelStation stationB = new ParcelStation("Station B");
        private static Transport transport1 = new Transport("Mot Station A");
        private static Transport transport2 = new Transport("Mot Station B");
        private static Transport transport3 = new Transport("Mot Ombud B");

       
        public ConsoleMenuAdministrator(ParcelRegistry registry)
        {
            this.registry = registry;
            ombudA = new ServicePoint("Ombud A",registry);
            ombudB = new ServicePoint("Ombud B",registry);

        }

        public void GetConsoleAdimistratorMenu()
        {
            ParcelCreator createNewParcel = new ParcelCreator();
            ParcelCreator createNewParcelAdministrator = new ParcelCreator();
            Parcel parcel;
            bool adminMenuBool = true;
            while (adminMenuBool)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("      POSTAL SERVICE ADMINSTRATÖR");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Registrera paket");
                Console.WriteLine("2. Spåra paket med försändelse-ID");
                Console.WriteLine("3. Visa alla paket i systemet");
                Console.WriteLine("4. Avsluta programmet");
                Console.WriteLine("========================================");
                Console.WriteLine();
                Console.WriteLine(" Eller välj:");
                Console.WriteLine();
                Console.WriteLine("5. Ombud A");
                Console.WriteLine("6. Station A");
                Console.WriteLine("7. Station B");
                Console.WriteLine("8. Ombud B");
                Console.WriteLine();
                Console.WriteLine("========================================");
                Console.Write("Välj ett alternativ: ");

                string adminChoice = Console.ReadLine();
                Console.Clear();

                switch (adminChoice)
                {
                    case "1":
                        //metod för att registrera paket
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


                            //Användaren kan trycka på esc för att återgå till menyn.
                            if (ReturnOnEscapeAdministrator())
                            {
                                return;
                            }

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

                            EscapeToMenuAdmin();
                            break;                    
                        }
                        break;

                    case "3":
                        //Visa alla paket i Dictionary
                        registry.ShowAllParcels();
                        EscapeToMenuAdmin();
                        break;

                    case "4":
                        Console.WriteLine("*************************");
                        Console.WriteLine("*                       *");
                        Console.WriteLine("*  Programmet avslutas  *");
                        Console.WriteLine("*                       *");
                        Console.WriteLine("*************************");
                        Environment.Exit(0);
                        break;

                    case "5":
                        GetOmbudAMenu();
                        break;

                    case "6":
                        Console.Clear();
                        GetStationAMenu();
                        break;

                    case "7":
                        GetStationBMenu();
                        break;

                    case "8":
                        GetOmbudBMenu();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ogiltig input");
                        Console.WriteLine();
                        Console.WriteLine("Vänligen skriv enbart den specificerade siffran för det du vill göra. ");
                        Console.WriteLine();
                        Console.ResetColor();
                        break;
                }
            }
        }

        public void GetOmbudAMenu()
        {
            bool ombudALoop = true; 

            while(ombudALoop)
            { 
                Console.WriteLine("========================================");
                Console.WriteLine("               OMBUD A");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Ta emot registrerade paket");
                Console.WriteLine("2. Skicka vidare paket");
                Console.WriteLine("3. Visa alla paket");
                Console.WriteLine("========================================");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Tryck Enter för att gå tillbaka");
                Console.ResetColor();
                Console.WriteLine("------------------------------");

                string ombudAChoice = Console.ReadLine();
                Console.Clear();

                    switch (ombudAChoice)
                    {
                        case "1":
                            ombudA.RecieveRegisteredParcel();
                            break;

                        case "2":
                            ombudA.LoadParcelFromServicePointToTransport(transport1);
                            break;

                        case "3":
                            ombudA.ViewServicePointOutgoingParcels();
                            break;

                        case "":
                            Console.Clear();
                            return;

                        default:
                            Console.WriteLine("Ogiltig input. ");
                            break;

                }
            }
        }

        public void GetOmbudBMenu()
        {
            bool ombudBLoop = true;

            while (ombudBLoop)
            { 
                Console.WriteLine("========================================");
                Console.WriteLine("               OMBUD B");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Hämta ut levererat paket");
                Console.WriteLine("2. Ta emot paket från transport");
                Console.WriteLine("3. Visa alla paket");
                Console.WriteLine("4. Visa paket från transport som kan tas emot");
                Console.WriteLine("========================================");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Tryck Enter för att gå tillbaka");
                Console.ResetColor();
                Console.WriteLine("------------------------------");

                string ombudAChoice = Console.ReadLine();
                Console.Clear();

                    switch (ombudAChoice)
                    {
                        case "1":
                            Console.Write("Ange försändelse-id: ");
                            if (int.TryParse(Console.ReadLine(), out int pickUpId))
                            {

                                ombudB.PickUpParcel(pickUpId);
                            }
                            else
                            {
                                Console.WriteLine("Id:t måste vara en siffra.");
                            }
                            break;

                        case "2":
                            transport3.DeliverParcels(ombudB);
                            break;

                        case "3":
                            ombudB.ViewServicePointOutgoingParcels();
                            break;

                        case "4":
                            transport3.ViewParcelsInTransport();
                            break;

                        case "":
                            Console.Clear();
                            return;

                        default:
                            Console.WriteLine("Ogiltig input. ");
                            break;
                }
            }
        }

        public void GetStationAMenu()
        {
            bool stationAloop = true;

            while (stationAloop)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("               STATION A");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Ta emot paket");
                Console.WriteLine("2. Skicka vidare paket");
                Console.WriteLine("3. Visa alla paket");
                Console.WriteLine("4. Visa paket från transport som kan tas emot");
                Console.WriteLine("========================================");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Tryck Enter för att gå tillbaka");
                Console.ResetColor();
                Console.WriteLine("------------------------------");

                string ombudAChoice = Console.ReadLine();
                Console.Clear();

                switch (ombudAChoice)
                {
                    case "1":
                        stationA.AddParcelTowardsDestinationB(transport1);
                        break;

                    case "2":
                        stationA.LoadParcelFromParcelStationToTransportTowardsDestinationB(transport2);
                        break;

                    case "3":
                        stationA.ViewParcelsGoingToDestinationB();
                        break;

                    case "4":
                        transport1.ViewParcelsInTransport();
                        break;

                    case "":
                        Console.Clear();
                        return;

                    default:
                        Console.WriteLine("Ogiltig input. ");
                        break;
                }
            }
        }

        public void GetStationBMenu()
        {
            bool stationBLoop = true;

            while (stationBLoop)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("               STATION B");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Ta emot paket");
                Console.WriteLine("2. Skicka vidare paket");
                Console.WriteLine("3. Visa alla paket");
                Console.WriteLine("4. Visa paket från transport som kan tas emot");
                Console.WriteLine("========================================");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Tryck Enter för att gå tillbaka");
                Console.ResetColor();
                Console.WriteLine("------------------------------");

                string ombudAChoice = Console.ReadLine();
                Console.Clear();

                switch (ombudAChoice)
                {
                    case "1":
                        stationB.AddParcelTowardsDestinationB(transport2);
                        break;

                    case "2":
                        stationB.LoadParcelFromParcelStationToTransportTowardsDestinationB(transport3);
                        break;

                    case "3":
                        stationB.ViewParcelsGoingToDestinationB();
                        break;

                    case "4":
                        transport2.ViewParcelsInTransport();
                        break;

                    case "":
                        Console.Clear();
                        return;

                    default:
                        Console.WriteLine("Ogiltig input. ");
                        break;
                }
            }
        }

        public void EscapeToMenuAdmin()
        {
            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
            Console.Clear();
        }

        //Ge användaren möjlighet att gå tillbaka till menyn genom att tryck på esc-knappen
        //ifall användaren inte har rätt data för att gå vidare. 
        private bool ReturnOnEscapeAdministrator()
        {
            if ((Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                Console.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
