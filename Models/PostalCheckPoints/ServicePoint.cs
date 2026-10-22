using PostalService.Model.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models.PostalCheckPoints
{
    internal class ServicePoint
    {
        //Location måste sättas och kan inte ändras
        public required string Location { get; init; }
        public int Priority { get; }
        public DateTime ParcelRecievedDate { get;  }

        //returnerar hur många paket som finns i kön just nu
        public int Count => ServicePointQueue.Count;

        //string ska vara paketobjektet
        private readonly PriorityQueue< string, (int, DateTime)> ServicePointQueue = new(); 

        //Detta behövs förmodligen i paket-klass vid registrering men lämnar här sålänge
        //Tupeln är kanske något som kopplas vid ombud? Objektet görs vid registreringen och tupeln kopplas vid ombud
        
        public ServicePoint(int priority, DateTime parcelRecievedDate)
            { 
                Priority = priority;
                ParcelRecievedDate = parcelRecievedDate;            
            }

        //lägga till paketobjekt i kön. Objekt ska vara i parantesen
       
            //public bool AddParcel(Parcel parcel)
            //{
            //    if (parcel.State is not PendingState)
            //    return false;                                      // bara registrerade paket tas emot

            //    parcel.parcelRecievedDate = DateTime.Now;          // tupelns info sätts här
            //    parcel.Location = Location;
            //    parcel.NextState();                        // Registrerat -> Inlämnat hos ombud

            //    ServicePointQueue.Enqueue(parcel, (parcel.Priority, parcel.parcelReceivedDate.Value));
            //    return true;
            //}
    
        //Lasta ut paket och lägga till paket till transport
        //public bool AddParcelFromTransport()
        //{
        //    if (Transport.TryDequeue(out var parcel, out _))
        //    {
        //        Transport.AddParcelToTransport(parcel);
        //        return true;
        //    }
        //    return false;
        //}

        //behövs metod för att lasta av från transport
        //public bool LoadParcelToTransport()
        //{
        //    if (ServicePoint.TryDequeue(out var parcel, out _))
        //    {
        //        Transport.AddParcelToTransport(parcel);
        //        return true;
        //    }
        //    return false;
        //}




    }
}
