using PostalService.Models.PostalCheckPoints;
using PostalService.Models.State;

namespace PostalService.Models
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Parcel parcel = new Parcel(1, 150m);
            //Console.WriteLine(parcel);

            DemoClass.Run();



            //Testkod
            //Ska flyttas ihop med menyerna 
            var registry = new ParcelRegistry();          // skapar paket 1001–1005
            var parcels = registry.GetAll().ToList();

            //Ombuden
            var ombudLudvika = new ServicePoint { Location = "Ombud Ludvika", Destination = 1 };
            var ombudBorlange = new ServicePoint { Location = "Ombud Borkänge", Destination = 2 };
            
            //terminalerna
            var terminalA = new ParcelStation { Location = "Terminal A"};
            var terminalB = new ParcelStation { Location = "Terminal A" };

            //Transporterna
            var transport1 = new Transport("Transport 1", "Under transport. Från Ombud Ludvika mot Terminal A");
            var transport2 = new Transport("Transport 2", "Under transport. Från Terminal A mot Terminal B");
            var transport3 = new Transport("Transport 3", "Under transport. Från Terminal B mot Ombud Borlänge");
            var transport4 = new Transport("Transport 4", "Under transport. Från Ombud Borlänge mot Terminal B.");
            var transport5 = new Transport("Transport 5", "Under transport. Från Terminal B mot Terminal A");
            var transport6 = new Transport("Transport 6", "Under transport. Från Terminal A mot Ombud Ludvika");

            //Ombud Ludvika(Plats A) => Terminal A => Terminal B => Borlänge(Plats B)

            //Ta emot registrerat paket. Ombud Ludvika. 
            //Console.WriteLine("Vilket paket vill du registrera?");
            //Kunna ta in ett paket från användaren som används i nedan metod. Paketet ska in i parantesen
            //ombudLudvika.RecieveRegisteredParcel();
            //lasta paket som finns vid ombud som transporterar dem till Terminal A
            ombudLudvika.LoadParcelFromServicePointToTransport(transport1);
            //Föra över retur-paket till ombud som kommer från Terminal A
            transport6.DeliverParcels(ombudBorlange);
            //Kolla på vilka paket som lämnats in och sen ska åka vidare
            ombudLudvika.ViewServicePointOutgoingParcels();
            //kolla på paket som kommit fram till destination och är färdiga att hämtas ut
            ombudLudvika.ViewDeliveredParcels();
            {

                //Ta emot registrerat paket. Ombud Borlänge. 
                //Console.WriteLine("Vilket paket vill du registrera?");
                //Kunna ta in ett paket från användaren som används i nedan metod. Paketet ska in i parantesen
                //ombudBorlänge.RecieveRegisteredParcel();
                //lasta paket som finns vid ombud som transporterar dem till Terminal B. Retur, back again 
                ombudBorlange.LoadParcelFromServicePointToTransport(transport1);
                //Föra över paket som är framme vid sin destination.             
                transport3.DeliverParcels(ombudBorlange);
                //Kolla på vilka paket som lämnats in och sen ska åka vidare
                ombudBorlange.ViewServicePointOutgoingParcels();
                //kolla på paket som kommit fram till destination och är färdiga att hämtas ut
                ombudBorlange.ViewDeliveredParcels();

                //Terminal A 
                //Lägga till paket från transport som kommer från Ludvika och är påväg till Desionation B (there)
                terminalA.AddParcelTowardsDestinationB(transport1);
                //Retur. Lägga till paket från transport som kommer ifrån Terminal B som är påväg till Desionation A (back again)
                terminalA.AddParcelTowardsDestinationB(transport5);
                //Ladda transport med paket mot Borlänge (Plats B, there)
                terminalA.LoadParcelFromParcelStationToTransportTowardsDestinationB(transport2);
                //Ladda transport med paket som är påväg till ombud Ludvika (Plats A, back again)
                terminalA.LoadParcelFromParcelStationToTransportTowardsDestinationA(transport6);
                //Kolla alla paket som finns i kön påväg till Borlänge (Plats B, there)
                terminalA.ViewParcelsGoingToDestinationB();
                //Kolla alla paket som finns i returkön påväg till Ludvika (Plats B, back again)
                terminalA.ViewParcelsGoingToDestinationA();

                //Terminal B
                //Lägga till paket från transport som kommer från Terminal A och är påväg till Borlänge (Desionation B, there)
                terminalB.AddParcelTowardsDestinationB(transport2);
                //Retur. Lägga till paket från transport som kommer ifrån ombud Borlänge och är påväg till Desionation A (back again)
                terminalB.AddParcelTowardsDestinationB(transport4);
                //Ladda transport med paket mot ombud Borlänge (Plats B, there)
                terminalB.LoadParcelFromParcelStationToTransportTowardsDestinationB(transport3);
                //Ladda transport med paket mot Terminal A (Plats B, back again)
                terminalB.LoadParcelFromParcelStationToTransportTowardsDestinationA(transport5);
                //Kolla alla paket som finns i kön påväg till Borlänge (Plats B, there)
                terminalB.ViewParcelsGoingToDestinationB();
                //Kolla alla paket som finns i returkön påväg till Ludvika (Plats B, back again)
                terminalB.ViewParcelsGoingToDestinationA();

                //Kunna kolla vilka paket som finns i de olika transporterna
                transport1.ViewParcelsInTransport();
                transport2.ViewParcelsInTransport();
                transport3.ViewParcelsInTransport();
                transport4.ViewParcelsInTransport();
                transport5.ViewParcelsInTransport();
                transport6.ViewParcelsInTransport();

                //Behöver också kunna söka paket





            } 

           
        }

    }
}
