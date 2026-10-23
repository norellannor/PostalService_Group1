using PostalService.Models.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models.PostalCheckPoints
{
    public class ServicePoint
    {
        //Location måste sättas och kan inte ändras
        public required string Location { get; init; }
        
        //returnerar hur många paket som finns i kön just nu
        public int Count => ServicePointQueue.Count;

        //Priorityqueuen som finns för paket som ska iväg
        private readonly PriorityQueue< Parcel, (int, DateTime)> ServicePointQueue = new();

        //Queue som finns för paket som är klara för att hämtas av mottagare
        private readonly Queue<Parcel> ServicePointReadyDeliveredQueue = new();





        //lägga till paketobjekt i kön. Objekt ska vara i parantesen

        public bool RecieveRegisteredParcel(Parcel parcel)
        {
            if (parcel.Status.State is not PendingState)              //eller jämföra med dictionary
                return false;                                      // bara registrerade paket tas emot

            parcel.AddParcelReceivedDate();
            parcel.NextState();                        // Registrerat och ändrar till nästa state
            parcel.UpdateParcelLocation(Location);      // tupelns ParcelRecievedDate sätts här
           

            ServicePointQueue.Enqueue(parcel, (parcel.Priority, parcel.ParcelReceivedDate.Value));
            return true;
        }

        //Lasta ut från ombud och lägga till paket till transport
        public bool LoadParcelFromServicePointToTransport(Transport transport)
        {
            if (!ServicePointQueue.TryDequeue(out var parcel, out _))
                return false;                          // väg 1: kön är tom

            if (parcel.Status.State is ParcelRecievedState)
                parcel.NextState();

            transport.AddParcelToTransport(parcel);
            return true;                               // väg 2: allt gick bra
        }

            //behövs metod för att ta emot från transport
        public bool LoadDeliveredParcelFromTransportToServicePoint(Transport transport)
        {
            var parcel = transport.RemoveParcelFromTransport();   // paketet tas ur TransportQueue
            if (parcel is null)
                return false;                                     // transporten var tom

            parcel.NextState();                                   // Från state Shipped till Delivered
            parcel.UpdateParcelLocation(Location);                // platsen blir ombudet

            ServicePointReadyDeliveredQueue.Enqueue(parcel);
            return true;
        }




    }
}
