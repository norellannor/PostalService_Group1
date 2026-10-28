using PostalService.Models.ShippingStrategy;
using PostalService.Models.State;
using PostalService.Models.WeightStrategy;
using PostalService.Models.Observer;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Text;
using System.Xml.Linq;


namespace PostalService.Models
{
    public class Parcel : ISubject
    {
        public int Id { get; private set; }
        public decimal Weight { get; private set; }
        public IWeightStrategy WeightStrategy { get; private set; }
        //strängen Location som uppdaterar sig beroende på vart vi är. Ska vara tom från början. 
        //public string? Location => Status.Location;

        public int Priority { get; }
        public DateTime? ParcelRecievedDate { get; private set; }
        public int? Destination { get; private set; }
       

        public Customer Sender { get; private set; }
        public Customer Receiver { get; private set; }

        public IShippingStrategy ShippingStrategy { get; private set; }

        public DateTime SentDate { get; private set; }

        public ParcelStatus Status { get; } = new ParcelStatus();
        //Paket mottaget vid ombud, behövs till tupeln. Börjar som null och sätts när mottagen

        //lista för observers
        private readonly List<IObserver> _observers = new List<IObserver>();




        //public void NextState() => Status.NextState();
        public void NextState()
        {
            Status.NextState();
            NotifyObservers(this);

        }
        //public void UpdateParcelLocation(string newLocation) => Status.ChangeTo(newLocation);



        public Parcel(decimal weight, Customer sender, Customer receiver, IShippingStrategy shippingStrategy )//int priority = 2
        {
            Weight = weight;
            Sender = sender;
            Receiver = receiver;
            ShippingStrategy = shippingStrategy;
            SentDate = DateTime.Today;
            WeightStrategy = SetWeightStrategy(weight);
            //Priority = priority;
        }


        //Denna metod ska sedan vara i klassen som kunden skapar sitt paket i. Detta ska validera vilken strategy som ska väljas.
        public IWeightStrategy SetWeightStrategy(decimal weight)
        {

            if (weight <= 2)
                return new LightWeight();
            else if (weight <= 15)
                return new MediumWeight();
            else
                return new HeavyWeight();
        }

        //Denna metod gör då att paketet känner till sitt Id som den får i ParcelRegistry.AddParcel()
        public void AssignId(int id)
        {
            Id = id;
        }

        

        public decimal GetTotalShippingPrice()
        {

            return ShippingStrategy.BasePrice + WeightStrategy.CalculateWeightPrice(Weight);

        }


        public override string ToString()
        {
            return $"Försändelse-id: {Id}\n" +
                   $"Vikt: {Weight} kg\n" +
                   $"Avsändare: {Sender}, {Sender.Address}\n" +
                   $"Mottagare: {Receiver}, {Receiver.Address}\n" +
                   $"Frakt: {ShippingStrategy.ShippingType}\n" +
                   $"kostnad:{GetTotalShippingPrice()}:-\n" +
                   $"Beräknad leverans: {ShippingStrategy.CalculateEstimatedDeliveryDate(SentDate):d}";

        }

        //Tar in paketets inlämningsdatum 
        
        public void AddParcelRecievedDate()
        {
            ParcelRecievedDate = DateTime.Now;
        }

        public void AddParcelDestination()
        { 
            Destination = Destination;
        }


        // metoder för observer
        // registererar/lägger till observer i listan. 
        public void RegisterObserver(IObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        // tar bort observer från listan.
        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        // notifierar observer. 
        public void NotifyObservers(Parcel parcel)
        {
            foreach (IObserver observer in _observers)
            {
                observer.Update(parcel);
            }
        }
    }
}
