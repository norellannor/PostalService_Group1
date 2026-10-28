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
        //public required string Location { get; init; }

        //returnerar hur många paket som finns i kön just nu
        public int Count => ServicePointQueue.Count;

        //Priorityqueuen som finns för paket som ska iväg
        private readonly PriorityQueue<Parcel, (int, DateTime)> ServicePointQueue = new();

        //Queue som finns för paket som är klara för att hämtas av mottagare
        //Kom på att queue för att hämta ut inte var det smartaste
        //private readonly Queue<Parcel> ServicePointDeliveredQueue = new();
        private readonly Dictionary<int, Parcel> ServicePointDeliveredParcelsDictionary = new();

        //public int Destination { get; init; }


        ParcelRegistry registry = new ParcelRegistry();

        //lägga till paketobjekt i kön. 

        public bool RecieveRegisteredParcel(Parcel parcel)
        {
            if (parcel.Status.State is not PendingState)              //eller jämföra med dictionary
                return false;                                      // bara registrerade paket tas emot

            //parcel.AddParcelDestination();
            parcel.AddParcelRecievedDate();
            parcel.NextState();
            Console.WriteLine();
            // Registrerat och ändrar till nästa state
            //parcel.UpdateParcelLocation(Location);      // tupelns ParcelRecievedDate sätts här


            ServicePointQueue.Enqueue(parcel, (parcel.Priority, parcel.ParcelRecievedDate.Value));
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
            Console.WriteLine();
            return true;                               // väg 2: allt gick bra
        }

        //behövs metod för att ta emot från transport
        //Queue, inte smart när man ska hämta ut 
        //public bool LoadDeliveredParcelFromTransportToServicePoint(Transport transport)
        //{
        //    var parcel = transport.RemoveParcelFromTransport();   // paketet tas ur TransportQueue
        //    if (parcel is null)
        //        return false;                                     // transporten var tom

        //    parcel.NextState();                                   // Från state Shipped till Delivered
        //    parcel.UpdateParcelLocation(Location);                // platsen blir ombudet

        //    ServicePointDeliveredQueue.Enqueue(parcel);
        //    return true;
        //}

        public void ReceiveDeliveredParcel(Parcel parcel)
        {
            //byter till DeliveredState
            parcel.NextState();
            //parcel.UpdateParcelLocation(Location);
            ServicePointDeliveredParcelsDictionary[parcel.Id] = parcel;
        }

        public void PickUpParcel(Parcel parcel)
        {
            string IdCheck = "";
            Console.WriteLine("Har du legitimation?");
            Console.WriteLine("1. ja");
            Console.WriteLine("2. nej");
            IdCheck=Console.ReadLine();

            switch(IdCheck)
            {
                case "1":
                    registry.FindParcelById(parcel.Id); 
                    break;
                case "2":
                    Console.WriteLine("Då kan vi inte lämna ut");
                    break;
                    
            }
            
        }
      


        //Vilka detaljer vill vi skriva ut 
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






        }
    }
