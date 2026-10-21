using System;
using System.Collections.Generic;
using System.Text;

namespace postalservice.Models
{
    public class Parcel
    {
        public int Id { get; set; }
        public decimal Weight { get; set; }

        //public Address AddressSender { get; set; }

        //public Address AddressReceiver { get; set; }
        //public Customer Sender { get; set; }
        //public Customer Receiver { get; set; }

        //Har ska vi ha STATE get set osv 
        //ShippingStrategy 
        //WeightStrategy 

        //


        public Parcel(int id, decimal weight) 
        //Address addressSender, Address addressReceiver, Customer sender, Customer receiver)
        {
            Id = id;
            Weight = weight;
            //AddressSender = addressSender;
            //AddressReciver = addressReceiver;
            //Sender = sender;
            //Reciver = receiver;
                     
        }

        

    }
}
