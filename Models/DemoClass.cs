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

            //Testkod
            //Ska flyttas ihop med menyerna 
            //var registry = new ParcelRegistry();          // skapar paket 1001–1005
            //var parcels = registry.GetAll().ToList();

            ////Ombuden
            //var ombudLudvika = new ServicePoint { Location = "Ombud Ludvika", Destination = 1 };
            //var ombudBorlange = new ServicePoint { Location = "Ombud Borlänge", Destination = 2 };

            ////terminalerna
            //var terminalA = new ParcelStation { Location = "Terminal A" };
            //var terminalB = new ParcelStation { Location = "Terminal B" };

            //Transporterna
            //var transport1 = new Transport("Transport 1", "Under transport. Från Ombud Ludvika mot Terminal A");
            //var transport2 = new Transport("Transport 2", "Under transport. Från Terminal A mot Terminal B");
            //var transport3 = new Transport("Transport 3", "Under transport. Från Terminal B mot Ombud Borlänge");
            //var transport4 = new Transport("Transport 4", "Under transport. Från Ombud Borlänge mot Terminal B.");
            //var transport5 = new Transport("Transport 5", "Under transport. Från Terminal B mot Terminal A");
            //var transport6 = new Transport("Transport 6", "Under transport. Från Terminal A mot Ombud Ludvika");

            //Ombud Ludvika(Plats A) => Terminal A => Terminal B => Borlänge(Plats B)

            //Ta emot registrerat paket. Ombud Ludvika. 
            //Console.WriteLine("Vilket paket vill du registrera?");
            //Kunna ta in ett paket från användaren som används i nedan metod. Paketet ska in i parantesen
            //ombudLudvika.RecieveRegisteredParcel();
            //lasta paket som finns vid ombud som transporterar dem till Terminal A
            //ombudLudvika.LoadParcelFromServicePointToTransport(transport1);
            ////Föra över retur-paket till ombud som kommer från Terminal A
            //transport6.DeliverParcels(ombudBorlange);
            ////Kolla på vilka paket som lämnats in och sen ska åka vidare
            //ombudLudvika.ViewServicePointOutgoingParcels();
            ////kolla på paket som kommit fram till destination och är färdiga att hämtas ut
            //ombudLudvika.ViewDeliveredParcels();
            //{

                //Ta emot registrerat paket. Ombud Borlänge. 
                //Console.WriteLine("Vilket paket vill du registrera?");
                //Kunna ta in ett paket från användaren som används i nedan metod. Paketet ska in i parantesen
                //ombudBorlänge.RecieveRegisteredParcel();
                //lasta paket som finns vid ombud som transporterar dem till Terminal B. Retur, back again 
                //ombudBorlange.LoadParcelFromServicePointToTransport(transport1);
                //Föra över paket som är framme vid sin destination.             
                //transport3.DeliverParcels(ombudBorlange);
                ////Kolla på vilka paket som lämnats in och sen ska åka vidare
                //ombudBorlange.ViewServicePointOutgoingParcels();
                ////kolla på paket som kommit fram till destination och är färdiga att hämtas ut
                //ombudBorlange.ViewDeliveredParcels();

                ////Terminal A 
                ////Lägga till paket från transport som kommer från Ludvika och är påväg till Desionation B (there)
                //terminalA.AddParcelTowardsDestinationB(transport1);
                ////Retur. Lägga till paket från transport som kommer ifrån Terminal B som är påväg till Desionation A (back again)
                ////terminalA.AddParcelTowardsDestinationA(transport5);
                ////Ladda transport med paket mot Borlänge (Plats B, there)
                //terminalA.LoadParcelFromParcelStationToTransportTowardsDestinationB(transport2);
                ////Ladda transport med paket som är påväg till ombud Ludvika (Plats A, back again)
                ////terminalA.LoadParcelFromParcelStationToTransportTowardsDestinationA(transport6);
                ////Kolla alla paket som finns i kön påväg till Borlänge (Plats B, there)
                //terminalA.ViewParcelsGoingToDestinationB();
                //Kolla alla paket som finns i returkön påväg till Ludvika (Plats B, back again)
                //terminalA.ViewParcelsGoingToDestinationA();

                //Terminal B
                //Lägga till paket från transport som kommer från Terminal A och är påväg till Borlänge (Desionation B, there)
                //terminalB.AddParcelTowardsDestinationB(transport2);
                //////Retur. Lägga till paket från transport som kommer ifrån ombud Borlänge och är påväg till Desionation A (back again)
                ////terminalB.AddParcelTowardsDestinationB(transport4);
                ////Ladda transport med paket mot ombud Borlänge (Plats B, there)
                //terminalB.LoadParcelFromParcelStationToTransportTowardsDestinationB(transport3);
                ////Ladda transport med paket mot Terminal A (Plats B, back again)
                ////terminalB.LoadParcelFromParcelStationToTransportTowardsDestinationA(transport5);
                ////Kolla alla paket som finns i kön påväg till Borlänge (Plats B, there)
                //terminalB.ViewParcelsGoingToDestinationB();
                ////Kolla alla paket som finns i returkön påväg till Ludvika (Plats B, back again)
                ////terminalB.ViewParcelsGoingToDestinationA();

                ////Kunna kolla vilka paket som finns i de olika transporterna
                //transport1.ViewParcelsInTransport();
                //transport2.ViewParcelsInTransport();
                //transport3.ViewParcelsInTransport();
                //transport4.ViewParcelsInTransport();
                //transport5.ViewParcelsInTransport();
                //transport6.ViewParcelsInTransport();

                //Behöver också kunna söka paket



                //ConsoleMenu menu = new ConsoleMenu();

                //menu.Menu();
            var ombudLudvika = new ServicePoint { Location = "Ombud Ludvika", Destination = 1 };
            var ombudBorlange = new ServicePoint { Location = "Ombud Borlänge", Destination = 2 };
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
            transport3.DeliverParcels(ombudBorlange);



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
