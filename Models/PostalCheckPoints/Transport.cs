using PostalService.Models.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models.PostalCheckPoints
{
    public class Transport
    {
        public string Location { get; }

        public Transport(string location)
        {
            Location = location;
        }
        public int Count => TransportQueue.Count;
        private readonly Queue<Parcel> TransportQueue = new();

        public void AddParcelToTransport(Parcel parcel)
        {
            parcel.UpdateParcelLocation($"{Location}");
            TransportQueue.Enqueue(parcel);
        }

        public Parcel? RemoveParcelFromTransport()
        {
            if (TransportQueue.TryDequeue(out var parcel))
            {
                return parcel;   
            }
            else
            {
                Console.WriteLine("Finns inga paket att ta emot.");
                return null;     
            }
        }

        public void DeliverParcels(ServicePoint servicePoint)
        {
            if (TransportQueue.Count == 0)
            {
                Console.WriteLine("Finns inga paket att ta emot.");
                return;
            }

            while (TransportQueue.TryDequeue(out Parcel? parcel))
            {
                servicePoint.ReceiveDeliveredParcel(parcel);
            }
        }
        
        public void ViewParcelsInTransport()
        {
            if (TransportQueue.Count == 0)
            {
                Console.WriteLine($"Finns inga paket här.");
                return;
            }
            foreach (var parcel in TransportQueue)
            {
                Console.WriteLine($"{parcel}");
                Console.WriteLine();
            }
        }
    }
}
