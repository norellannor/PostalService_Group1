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
        public string? Location { get; private set; }

        public int Priority => ShippingStrategy.Priority;
        public DateTime? ParcelRecievedDate { get; private set; }

        /*Egenskap som sätter det beräknade leveransdatumet baserat på vilken frakttyp som valts. 
        Om paketet inte är inlämnat så är datumet null, inlämnat paket får inlämnat datum plus datum 
        enl. vald strategi/frakttyp.*/ 
        public DateTime? EstimatedDeliveryDate
        {
            get
            {
                if (ParcelRecievedDate == null)
                {
                    return null;
                }

                return ShippingStrategy.CalculateEstimatedDeliveryDate(ParcelRecievedDate.Value);
            }
        }

        // Egenskap för datumet då paketet är levererat men ännu inte mottaget av mottagare. 
        public DateTime? DeliveredParcelDate { get; private set; }
        public Customer Sender { get; private set; }
        public Customer Receiver { get; private set; }

        public IShippingStrategy ShippingStrategy { get; private set; }

        public DateTime SentDate { get; private set; }

        public ParcelStatus Status { get; } = new ParcelStatus();
        

        //lista för observers
        private readonly List<IObserver> _observers = new List<IObserver>();

        public void NextState()
        {
            Status.NextState();
            //Skriver ut vid alla stationer. 
            Console.WriteLine($"{Id} \n Frakttyp:{ShippingStrategy.ShippingType} \n prio:{Priority} \n {Status.State.StateText}");
            NotifyObservers(this);

        }
        public void UpdateParcelLocation(string newLocation)
        {
            Location = newLocation;
        }

        public Parcel(decimal weight, Customer sender, Customer receiver, IWeightStrategy weightStrategy, IShippingStrategy shippingStrategy)//int priority = 2
        {
            Weight = weight;
            Sender = sender;
            Receiver = receiver;
            ShippingStrategy = shippingStrategy;
            SentDate = DateTime.Today;
            WeightStrategy = weightStrategy;
            //Priority = priority;
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
            string estimatedDeliveryDateText;

            if (EstimatedDeliveryDate == null)
            {
                estimatedDeliveryDateText = $"Beräknad leverans är inom {ShippingStrategy.DeliveryDays} dagar från inlämning";
            }
            else
            {
                estimatedDeliveryDateText = $"Beräknad leverans: {EstimatedDeliveryDate:d}";
            }

            string statusText = Status.State.StateText;

            if (IsParcelDelayed())
                statusText += "- FÖRSENAT";

            return $"Försändelse-id: {Id}\n" +
                   $"Status: {statusText}\n" +
                   $"Vikt: {Weight} kg\n" +
                   $"Avsändare: {Sender}, {Sender.Address}\n" +
                   $"Mottagare: {Receiver}, {Receiver.Address}\n" +
                   $"Frakt: {ShippingStrategy.ShippingType}\n" +
                   $"Prioritet: {Priority}\n" +
                   $"Kostnad:{GetTotalShippingPrice()}:-\n" +
                   //$"Beräknad leverans: {ShippingStrategy.CalculateEstimatedDeliveryDate(SentDate):d}";
                   //Beräknat leveransdatum borde vara inlämnat datum + de dagara som frakttypen säger. 
                   estimatedDeliveryDateText;


            //I denna metod kan vi lägga till vilken status paketet har eller om det bara ska synas om det är försenat 

        }

        //Tar in paketets inlämningsdatum 
        public void AddParcelRecievedDate()
        {
            ParcelRecievedDate = DateTime.Now.Date;
        }

        //Sätter datumet då paketet är levererat på ombudB. 
        public void SetParcelDeliveredDate()
        {
            DeliveredParcelDate = DateTime.Today;
        }

        //Metod för att kontrollera om paketet kommer fram i tid. 
        //Returnerar true om paketet är försenat. 
        public bool IsParcelDelayed()
        {
            //Paketet är inte inlämnat och det finns inget paket som kan vara försenat. 
            if (EstimatedDeliveryDate == null)
            {
                return false;
            }

            DateTime estimated = EstimatedDeliveryDate.Value.Date;

            // Paketet är levererat: jämför med dagen det kom fram
            if (DeliveredParcelDate != null)
            {
                return estimated < DeliveredParcelDate.Value.Date;
            }

            // Paketet är på väg: jämför med idag
            return estimated < DateTime.Today;
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
