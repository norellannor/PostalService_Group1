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
        public required string Location { get; init; }
        public int Priority { get; }
        public DateTime ParcelRecievedDate { get; }
       //Kö för Paket som är påväg mot plats A
        private readonly PriorityQueue<Parcel, (int, DateTime)> ParcelStationPriorityQueueTowardsDestinationA = new();
        //Kö för Paket som är påväg mot plats A
        private readonly PriorityQueue<Parcel, (int, DateTime)> ParcelStationPriorityQueueTowardsDestinationB = new();
        //behövs metod för att ta emot från transport
        //Mot A - there...
        public bool AddParcelTowardsDestinationA(Transport transport)
        {
            var parcel = transport.RemoveParcelFromTransport();   // paketet tas ur TransportQueue
            if (parcel is null)
                return false;                                     // transporten var tom

            parcel.UpdateParcelLocation(Location);                // platsen blir ombudet

            ParcelStationPriorityQueueTowardsDestinationA.Enqueue(parcel, (parcel.Priority, parcel.ParcelReceivedDate!.Value));
            return true;

        }

        //mot B - retur (...and back again)
        public bool AddParcelTowardsDestinationBFromTransportToParcelStation(Transport transport)
        {
            var parcel = transport.RemoveParcelFromTransport();   // paketet tas ur TransportQueue
            if (parcel is null)
                return false;                                     // transporten var tom

            parcel.UpdateParcelLocation(Location);                // platsen blir ombudet

            ParcelStationPriorityQueueTowardsDestinationA.Enqueue(parcel, (parcel.Priority, parcel.ParcelReceivedDate!.Value));
            return true;

        }
        public bool LoadParcelFromParcelStationToTransportDestinationA(Transport transport)
        {
            if (!ParcelStationPriorityQueueTowardsDestinationA.TryDequeue(out var parcel, out _))
                return false;                          // väg 1: kön är tom

            if (parcel.Status.State is ParcelRecievedState)

            transport.AddParcelToTransport(parcel);
            return true;                               // väg 2: allt gick bra
        }

        public bool LoadParcelFromParcelStationToTransportDestinationB(Transport transport)
        {
            if (!ParcelStationPriorityQueueTowardsDestinationB.TryDequeue(out var parcel, out _))
                return false;                          // väg 1: kön är tom

            if (parcel.Status.State is ParcelRecievedState)

                transport.AddParcelToTransport(parcel);
            return true;                               // väg 2: allt gick bra
        }
    }
}
