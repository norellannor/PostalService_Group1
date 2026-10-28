using PostalService.Models.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models.PostalCheckPoints
{
    public class ParcelStation
    {
        //public required string Location { get; init; }


        //Kö för Paket som är påväg mot plats B. There...
        private readonly PriorityQueue<Parcel, (int, DateTime)> ParcelStationPriorityQueueTowardsDestinationB = new();

        //...and back again. Kö för Paket som är påväg mot plats A.Retur
        //private readonly PriorityQueue<Parcel, (int, DateTime)> ParcelStationPriorityQueueTowardsDestinationA = new();

        //Mot B - there...
        public bool AddParcelTowardsDestinationB(Transport transport)
        {
            var parcel = transport.RemoveParcelFromTransport();   // paketet tas ur TransportQueue
            if (parcel is null)
                return false;                                     // transporten var tom

            //parcel.UpdateParcelLocation(Location);
            //Console.WriteLine("Paket är mottaget vid station");
            //SortedAtStationA
            ParcelStationPriorityQueueTowardsDestinationB.Enqueue(parcel, (parcel.Priority, parcel.ParcelRecievedDate!.Value));
            parcel.NextState();
            return true;

        }

        //mot A - retur (...and back again)
        //public bool AddParcelTowardsDestinationA(Transport transport)
        //{
        //    var parcel = transport.RemoveParcelFromTransport();   // paketet tas ur TransportQueue
        //    if (parcel is null)
        //        return false;                                     // transporten var tom

        //    parcel.UpdateParcelLocation(Location);                

        //    ParcelStationPriorityQueueTowardsDestinationA.Enqueue(parcel, (parcel.Priority, parcel.ParcelRecievedDate!.Value));
        //    return true;

        //}


        //There...
        public bool LoadParcelFromParcelStationToTransportTowardsDestinationB(Transport transport)
        {
            if (!ParcelStationPriorityQueueTowardsDestinationB.TryDequeue(out var parcel, out _))
                return false;                          // väg 1: kön är tom

            //Console.WriteLine("Påväg mot nästa plats");
            transport.AddParcelToTransport(parcel);
           //Intransportstate
            parcel.NextState();
            return true;                               // väg 2: allt gick bra
        }

        //...and back again
        //public bool LoadParcelFromParcelStationToTransportTowardsDestinationA(Transport transport)
        //{
        //    if (!ParcelStationPriorityQueueTowardsDestinationA.TryDequeue(out var parcel, out _))
        //        return false;

        //    transport.AddParcelToTransport(parcel);
        //    return true;
        //}

        // Tittar på alla paket som finns i terminalen påväg mot plats B
        public void ViewParcelsGoingToDestinationB()
        {
            if (ParcelStationPriorityQueueTowardsDestinationB.Count == 0)
            {
                Console.WriteLine($"Finns inga utgående paket här som ska till Borlänge.");
                Console.WriteLine();
                return;
            }
            foreach (var item in ParcelStationPriorityQueueTowardsDestinationB.UnorderedItems)
            {
                Console.WriteLine(item.Element);
                Console.WriteLine();
            }
        }
        //Tittar på alla paket i kön mot plats A. Retur 
        //public void ViewParcelsGoingToDestinationA()
        //{
        //    if (ParcelStationPriorityQueueTowardsDestinationA.Count == 0)
        //    {
        //        Console.WriteLine($"Finns inga paket här som ska till Ludvika.");
        //        Console.WriteLine();
        //        return;
        //    }
        //    foreach (var item in ParcelStationPriorityQueueTowardsDestinationA.UnorderedItems)
        //    {
        //        Console.WriteLine(item.Element);
        //        Console.WriteLine();
        //    }
        //}

    }
}
