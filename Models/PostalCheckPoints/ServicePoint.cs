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
        public string Location { get; }

        //returnerar hur många paket som finns i kön just nu
        public int Count => ServicePointQueue.Count;

        private readonly PriorityQueue<Parcel, (int, DateTime)> ServicePointQueue = new();

        private readonly Dictionary<int, Parcel> ServicePointDeliveredParcelsDictionary = new();


       
        private readonly ParcelRegistry registry;

      

        public ServicePoint(string location, ParcelRegistry registry)
        {
            Location = location;
            this.registry = registry;
        }


        public bool RecieveRegisteredParcel()
        {

            Console.Write("Ange försändelse-id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ogiltigt id, ange en siffra.");
                return false;
            }

            Parcel parcel = registry.FindParcelById(id);

            
            if (parcel == null)
            {
                Console.WriteLine("Paketet finns inte registrerat.");
                
                return false;
            }

            if (parcel.Status.State is not PendingState)
            {
                Console.WriteLine("Paketet finns registrerat men kan ej tas emot. Kontakta kundsupport.");
                return false;
            }

            
            parcel.AddParcelRecievedDate();
            parcel.UpdateParcelLocation(Location);
            parcel.NextState();
            Console.WriteLine();
            


            ServicePointQueue.Enqueue(parcel, (parcel.Priority, parcel.ParcelRecievedDate.Value));
            return true;
        }

        //Lasta ut från ombud och lägga till paket till transport
        public bool LoadParcelFromServicePointToTransport(Transport transport)
        {
            if (!ServicePointQueue.TryDequeue(out var parcel, out _))
            {
                Console.WriteLine("Finns inga paket att skicka.");
                return false;
            }

            if (parcel.Status.State is ParcelRecievedState)
            { 
            parcel.UpdateParcelLocation(Location);
            parcel.NextState(); 
            }

            transport.AddParcelToTransport(parcel);
            return true;                               
        }


        public void ReceiveDeliveredParcel(Parcel parcel)
        {
            
            //Sätter dagens datum till leveransdatum
            // dvs. det datum paketet kommer fram till ombud B. 
            parcel.SetParcelDeliveredDate();
            parcel.UpdateParcelLocation(Location);
            //byter till DeliveredState
            parcel.NextState();
            
            ServicePointDeliveredParcelsDictionary[parcel.Id] = parcel;
        }

        public void PickUpParcel(int parcelId)
        {
            if (!ServicePointDeliveredParcelsDictionary.TryGetValue(parcelId, out Parcel? parcel))
            {
                Console.WriteLine("Det finns inget paket med det id:t att hämta här.");
                return;
            }

            string IdCheck = "";
            Console.WriteLine("Har du legitimation?");
            Console.WriteLine("1. ja");
            Console.WriteLine("2. nej");
            IdCheck=Console.ReadLine();

            switch(IdCheck)
            {
                case "1":
                    RemoveDeliveredParcel(parcel.Id);
                    parcel.UpdateParcelLocation(Location);
                    parcel.NextState();


                    break;
                case "2":
                    Console.WriteLine("Då kan vi inte lämna ut");
                    break;
                    
            }
            
        }
      

        public void ViewServicePointOutgoingParcels()
        {
            if (ServicePointQueue.Count == 0)
            {
                Console.WriteLine($"Finns inga utgående paket.");
                return;
            }
            foreach (var item in ServicePointQueue.UnorderedItems)
            {
                Console.WriteLine(item.Element);
                Console.WriteLine();
            }
        }

        public void ViewDeliveredParcels()
        {
            if (ServicePointDeliveredParcelsDictionary.Count == 0)
            {
                Console.WriteLine($"Finns inga paket att hämtas ut..");
                return;
            }
            foreach (var parcel in ServicePointDeliveredParcelsDictionary)
            {
                Console.WriteLine($"{parcel}");
                Console.WriteLine();
            }
        }

        public void RemoveDeliveredParcel(int parcelId)
        {
            if (ServicePointDeliveredParcelsDictionary.ContainsKey(parcelId))
            {
                ServicePointDeliveredParcelsDictionary.Remove(parcelId);
                

            }
            else
            {
                Console.WriteLine("Paketet finns inte.");
            }

        }





    }
    }
