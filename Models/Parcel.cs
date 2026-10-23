using PostalService.Models.ShippingStrategy;
using PostalService.Models.State;
using PostalService.Models.WeightStrategy;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Xml.Linq;


namespace PostalService.Models
{
    public class Parcel
    {
        public int Id { get; private set; }
        public decimal Weight { get; private set; }
        public IWeightStrategy WeightStrategy { get; private set; }
        //strängen Location som uppdaterar sig beroende på vart vi är. Ska vara tom från början. 
        public string? Location => Status.Location; 
        

        //Tupeln. Priority ska sättas vid registrering
        public Parcel(int priority, DateTime parcelRecievedDate)
        {
            Priority = priority;
            ParcelRecievedDate = parcelRecievedDate;
        }
        public int Priority { get; }
        public DateTime? ParcelRecievedDate { get; private set; }
       

        //public Address AddressSender { get; private set; }
        //public Address AddressReceiver { get; private set; }  //Detta får man med Customer Sender och Reciver, man sätter det bara en gång
        //istället för att ta in det två gånger, en adress kan forfarande ha flera kunder. Det är som att sätta en adress på mormor först och sen mormors adress på paketet.
        public Customer Sender { get; private set; }
        public Customer Receiver { get; private set; }

        public IShippingStrategy ShippingStrategy { get; private set; }

        public DateTime SentDate { get; private set; }

        public ParcelStatus Status { get; } = new ParcelStatus();
        //Paket mottaget vid ombud, behövs till tupeln. Börjar som null och sätts när mottagen
        public DateTime? ParcelReceivedDate { get; private set; }

        //Har ska vi ha STATE get set osv 
        public IParcelState State { get; private set; } = new PendingState();
        public void NextState() => Status.NextState();
        public void UpdateParcelLocation(string newLocation) => Status.ChangeTo(newLocation);



        public Parcel(decimal weight, Customer sender, Customer receiver, IShippingStrategy shippingStrategy)
        {
            Weight = weight;
            Sender = sender;
            Receiver = receiver;
            ShippingStrategy = shippingStrategy;
            SentDate = DateTime.Today;
            WeightStrategy = SetWeightStrategy(weight);
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
        
        public void AddParcelReceivedDate()
        {
            ParcelReceivedDate = DateTime.Now;
        }

        
    }
}
