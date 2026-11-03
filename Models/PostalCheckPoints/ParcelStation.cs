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
        public string Location { get; }

        public ParcelStation(string location)
        {
            Location = location;
        }


        private readonly PriorityQueue<Parcel, (int, DateTime)> ParcelStationPriorityQueueTowardsDestinationB = new();

        public bool AddParcelTowardsDestinationB(Transport transport)
        {
            var parcel = transport.RemoveParcelFromTransport();   
            if (parcel is null)
                return false;                                     

           
            ParcelStationPriorityQueueTowardsDestinationB.Enqueue(parcel, (parcel.Priority, parcel.ParcelRecievedDate!.Value));
            parcel.UpdateParcelLocation(Location);
            parcel.NextState();
            return true;

        }

        
        public bool LoadParcelFromParcelStationToTransportTowardsDestinationB(Transport transport)
        {
            if (!ParcelStationPriorityQueueTowardsDestinationB.TryDequeue(out var parcel, out _))
                return false;                          

            
            transport.AddParcelToTransport(parcel);
            parcel.UpdateParcelLocation(Location);
            parcel.NextState();
            return true;                              
        }

        public void ViewParcelsGoingToDestinationB()
        {
            if (ParcelStationPriorityQueueTowardsDestinationB.Count == 0)
            {
                Console.WriteLine($"Finns inga utgående paket här.");
                Console.WriteLine();
                return;
            }
            foreach (var item in ParcelStationPriorityQueueTowardsDestinationB.UnorderedItems)
            {
                Console.WriteLine(item.Element);
                Console.WriteLine();
            }
        }
        

    }
}
