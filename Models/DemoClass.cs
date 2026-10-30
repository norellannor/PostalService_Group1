using Microsoft.Win32;
using PostalService.Models.ShippingStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostalService.Models.PostalCheckPoints;
using System.Xml.Serialization;

namespace PostalService.Models
{
    public class DemoClass
    {
        public static void Run()
        {


            Address addressReciver = new Address("Ängsvägen", "78542", "Mockfjärd");
            Address addressSender = new Address("Mossgatan", "77130", "Ludvika");

            Customer reciver = new Customer("Emelie Lind", addressReciver);
            Customer sender = new Customer("Erika Lind", addressSender);

            Address addressReciver2 = new Address("Storgatan", "22220", "Lund");
            Address addressSender2 = new Address("Lingonvägen", "77130", "Ludvika");



            Customer reciver2 = new Customer("Lisa Andersson", addressReciver2);
            Customer sender2 = new Customer(" Bengt Karlsson", addressSender2);

            IShippingStrategy shippingStrategy = new StandardShipping();
            IShippingStrategy shippingStrategy2 = new ExpressShipping();

            Parcel parcel = new Parcel(150m, sender, reciver, shippingStrategy);
            //Parcel parcel2 = new Parcel(1m, sender2, reciver2, shippingStrategy2);


            ParcelRegistry registry = new ParcelRegistry();
            registry.AddParcel(parcel);
            //registry.AddParcel(parcel2);


            //parcel.NextState(); // Registrerat -> Inlämnat
            //parcel.NextState(); // Inlämnat -> Sorterat A
            //parcel.NextState(); // Sorterat A -> Under transport
            //parcel.NextState(); // Under transport -> Sorterat B
            //parcel.NextState(); // Sorterat B -> Ute för leverans
            //parcel.NextState(); // Ute för leverans -> Levererat
            //parcel.NextState(); // Levererat -> Mottaget

            Console.WriteLine();

            var ombudLudvika = new ServicePoint();
            var ombudBorlange = new ServicePoint();
            var terminalA = new ParcelStation();
            var terminalB = new ParcelStation();
            var transport1 = new Transport();
            var transport2 = new Transport();
            var transport3 = new Transport();
            
            


            //ParcelRegistry registry = new ParcelRegistry();   // håller alla paket
            //parcelCreator creator = new ParcelCreator();      // frågar kunden och skapar paket

            ////Parcel parcel = creator.ConfirmCreatedParcel();   // skapa + bekräfta
            ////registry.AddParcel(parcel);
            //// spara i dictionaryn


            //ombudLudvika.RecieveRegisteredParcel(parcel);
            //ombudLudvika.ViewServicePointOutgoingParcels();

            //ombudLudvika.LoadParcelFromServicePointToTransport(transport1); //laddat paket till transport
            //transport1.ViewParcelsInTransport();

            //terminalA.AddParcelTowardsDestinationB(transport1);

            //terminalA.LoadParcelFromParcelStationToTransportTowardsDestinationB(transport2);
            //terminalB.AddParcelTowardsDestinationB(transport2);
            //terminalB.LoadParcelFromParcelStationToTransportTowardsDestinationB(transport3);
            //transport3.DeliverParcels(ombudBorlange);



            bool loopMenu = true;
            while (loopMenu)
            {

                Console.WriteLine("Ombud Ludvika");
                Console.WriteLine("1. Ta emot registrerade paket");
                Console.WriteLine("2. Skicka vidare paketet");
                Console.WriteLine("3. Visa alla paket");

                Console.WriteLine("Station A");
                Console.WriteLine("4. Ta emot registrerade paket");
                Console.WriteLine("5. Skicka vidare paketet");
                Console.WriteLine("6. Visa alla paket");

                Console.WriteLine("Station B");
                Console.WriteLine("7. Ta emot registrerade paket");
                Console.WriteLine("8. Skicka vidare paketet");
                Console.WriteLine("9. Visa alla paket");


                Console.WriteLine("Ombud Borlänge");
                Console.WriteLine("10. Ta emot paket");
                Console.WriteLine("11. Uthämtning");
                Console.WriteLine("12. Visa alla paket");

                string userInputFromMenu = Console.ReadLine();
                switch (userInputFromMenu)
                {
                    case "1":
                        ombudLudvika.RecieveRegisteredParcel(parcel);
                        break;
                    case "2":
                        ombudLudvika.LoadParcelFromServicePointToTransport(transport1);
                        break;
                    case "3":
                        ombudLudvika.ViewServicePointOutgoingParcels();

                        break;
                    case "4":
                        terminalA.AddParcelTowardsDestinationB(transport1);
                        break;
                    case "5":
                        terminalA.LoadParcelFromParcelStationToTransportTowardsDestinationB(transport2);
                        break;
                    case "6":
                        //transport1.ViewParcelsInTransport();
                        terminalA.ViewParcelsGoingToDestinationB();
                        break;
                    case "7":
                        terminalB.AddParcelTowardsDestinationB(transport2);
                        break;
                    case "8":
                        terminalB.LoadParcelFromParcelStationToTransportTowardsDestinationB(transport3);
                        break;
                    case "9":
                        terminalB.ViewParcelsGoingToDestinationB();
                        break;
                    case "10":
                        transport3.DeliverParcels(ombudBorlange);
                        break;
                    case "11":
                        Console.Write("Ange försändelse-id: ");
                        if (int.TryParse(Console.ReadLine(), out int pickUpId))
                        {
                            
                            ombudBorlange.PickUpParcel(pickUpId);
                        }
                        else
                        {
                            Console.WriteLine("Id:t måste vara en siffra.");
                        }
                        break;
                    case "12":
                        Console.WriteLine("Finns inte än");
                        break;

                        default:
                            Console.WriteLine("Ogiltigt val.");
                            break;

                }

            }
        }

        public static void ClearConsole() 
        { 
            Console.Clear();

        }
            
    }
}
