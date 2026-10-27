using Microsoft.Win32;
using PostalService.Models.ShippingStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostalService.Models.PostalCheckPoints;

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
            Parcel parcel2 = new Parcel(1m, sender2, reciver2, shippingStrategy2);


            ParcelRegistry registry = new ParcelRegistry();
            registry.AddParcel(parcel);
            registry.AddParcel(parcel2);


            //Console.WriteLine(parcel);
            //Console.WriteLine("...............");
            //Console.WriteLine(parcel2);

            //UserInput input = new UserInput();
            //input.ReadString("Ange ditt namn:");

            //ParcelCreator parcel = new ParcelCreator();
            //Parcel parcelTest = parcel.CreateParcel();




            //ConsoleMenu menu = new ConsoleMenu();

            //menu.Menu();
            var ombudLudvika = new ServicePoint { Location = "Ombud Ludvika", Destination = 1 };
            var ombudBorlange = new ServicePoint { Location = "Ombud Borkänge", Destination = 2 };
            var terminalA = new ParcelStation { Location = "Terminal A" };
            var terminalB = new ParcelStation { Location = "Terminal B" };
            var transport1 = new Transport("Transport 1", "Under transport. Från Ombud Ludvika mot Terminal A");
            var transport2 = new Transport("Transport 2", "Under transport. Från Terminal A mot Terminal B");
            var transport3 = new Transport("Transport 3", "Under transport. Från Terminal B mot Ombud Borlänge");
            //ParcelRegistry registry = new ParcelRegistry();   // håller alla paket
            //ParcelCreator creator = new ParcelCreator();      // frågar kunden och skapar paket

            //Parcel parcel = creator.ConfirmCreatedParcel();   // skapa + bekräfta
            //registry.AddParcel(parcel);
            // spara i dictionaryn


            ombudLudvika.RecieveRegisteredParcel(parcel);
            ombudLudvika.ViewServicePointOutgoingParcels();
            ombudLudvika.LoadParcelFromServicePointToTransport(transport1); //laddat paket till transport
            transport1.ViewParcelsInTransport();
            terminalA.AddParcelTowardsDestinationB(transport1);
            terminalA.LoadParcelFromParcelStationToTransportTowardsDestinationB(transport2);
            terminalB.AddParcelTowardsDestinationB(transport2);
            terminalB.LoadParcelFromParcelStationToTransportTowardsDestinationB(transport3);



            Console.WriteLine($"Paketet är registrerat \n {parcel}.");


            
            //ParcelRegistry registry = new ParcelRegistry();
            //registry.AddParcel(parcelTest);
            //Console.WriteLine(parcelTest);

            //Console.WriteLine("Sök på ett paket");
            //int parcelSearch = Int32.Parse(Console.ReadLine());

            //registry.FindParcelById(parcelSearch);
        }

           public static void ClearConsole()
        {
            Console.Clear();
        }
    }
}
