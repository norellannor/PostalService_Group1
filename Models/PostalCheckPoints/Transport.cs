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
        public string TransportName { get;  }
        public string Location { get; private set; } // Under transport, på väg mot 
        public int Count => TransportQueue.Count;
        public Transport(string transportName, string location)
        {
            TransportName = transportName;
            Location = location; 
        }
        //ändra string till paketobjekt
        private readonly Queue<Parcel> TransportQueue =new();

        //lägg till objektet, fattas
        public void AddParcelToTransport(Parcel parcel)
        {
            parcel.UpdateParcelLocation($"{TransportName}: {Location}");
            TransportQueue.Enqueue(parcel);
        }

        public Parcel? RemoveParcelFromTransport()
        {
            if (TransportQueue.TryDequeue(out var parcel))
            {
                return parcel;   // det fanns ett paket
            }
            else
            {
                return null;     // kön var tom
            }
        }

        //Vilka detaljer vill vi skriva ut 
        public void ViewTransportParcels()
        {
            if (TransportQueue.Count == 0)
            {
                Console.WriteLine($"{TransportName} är tom.");
                return;
            }
            foreach (var parcel in TransportQueue) 
            {
                Console.WriteLine($"{parcel}");
                Console.WriteLine();
            }
        }
        public void ViewParcelsInTransport()
        {
            if (TransportQueue.Count == 0)
            {
                Console.WriteLine($"Finns inga paket i transporten");
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
