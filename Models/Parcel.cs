using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using PostalService.Models.ShippingStrategy;
using PostalService.Models.WeightStrategy;


namespace PostalService.Models
{
    public class Parcel
    {
        public int Id { get; private set; }
        public decimal Weight { get; private set; }
        public IWeightStrategy WeightStrategy { get; private set; }

        public Customer Sender { get; private set; }
        public Customer Receiver { get; private set; }

        public IShippingStrategy ShippingStrategy { get; private set; }

        public DateTime SentDate { get; private set; }

        //Har ska vi ha STATE get set osv 


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
    }
}
