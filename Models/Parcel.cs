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

        //public Address AddressSender { get; private set; }
        //public Address AddressReceiver { get; private set; }  //Detta får man med Customer Sender och Reciver, man sätter det bara en gång
        //istället för att ta in det två gånger, en adress kan forfarande ha flera kunder. Det är som att sätta en adress på mormor först och sen mormors adress på paketet.
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
            WeightStrategy = ChooseWeightStrategy(weight);
        }

        //Denna metod gör då att paketet känner till sitt Id som den får i ParcelRegistry.AddParcel()
        public void AssignId(int id)
        {
            Id = id;
        }

        //Denna metod ska sedan vara i klassen som kunden skapar sitt paket i. Detta ska validera vilken strategy som ska väljas.
        private IWeightStrategy ChooseWeightStrategy(decimal weight)
        {

            if (weight <= 2)
                return new LightWeight();
            else if (weight <= 15)
                return new MediumWeight();
            else
                return new HeavyWeight();
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
