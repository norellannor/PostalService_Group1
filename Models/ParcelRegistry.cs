using PostalService.Models.ShippingStrategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostalService.Models
{
    public class ParcelRegistry
    {

        //Dictionary som hanterar paketet. Key = försändelseId och Value = paketet 
        private readonly Dictionary<int, Parcel> parcelsInSystem = new Dictionary<int, Parcel>();
        private int nextId = 1001;

        public ParcelRegistry() 
        {
            AddSampleParcels();
        }

        public void AddSampleParcels()
        {
            Customer erika = new Customer("Erika Lind", new Address("Mossgatan 4", "77130", "Ludvika"));
            Customer emelie = new Customer("Emelie Lind", new Address("Ängsvägen 12", "78542", "Mockfjärd"));
            Customer lisa = new Customer("Lisa Andersson", new Address("Storgatan 8", "22220", "Lund"));
            Customer bengt = new Customer("Bengt Karlsson", new Address("Lingonvägen 3", "77130", "Ludvika"));
            Customer anna = new Customer("Anna Berg", new Address("Kungsgatan 20", "11122", "Stockholm"));

            AddParcel(new Parcel(1.5m, erika, emelie, new StandardShipping()));   // 1001, lätt
            AddParcel(new Parcel(8m, bengt, lisa, new ExpressShipping()));        // 1002, medel
            AddParcel(new Parcel(22m, anna, erika, new EconomyShipping()));       // 1003, tung
            AddParcel(new Parcel(0.5m, lisa, bengt, new ExpressShipping()));      // 1004, lätt
            AddParcel(new Parcel(14m, emelie, anna, new StandardShipping()));     // 1005, medel
        }
        //Metod för att lägga till ett paket, samt generar en key, försändelseid
        public int AddParcel(Parcel parcel)
        {

            int id = nextId;   // ta nuvarande värde
            nextId++;          // öka till nästa gång
            parcel.AssignId(id);

            parcelsInSystem.Add(id, parcel);

            return id;
        }


        //Metod för att ta bort paket

        public void RemoveParcel(int parcelId) 
        { 
            if (parcelsInSystem.ContainsKey(parcelId))
            {
                parcelsInSystem.Remove(parcelId);
            }
           
        }

        public Parcel? FindParcelById(int parcelId)
        {
            if (parcelsInSystem.TryGetValue(parcelId, out Parcel? parcel))
            {
                return parcel;
            }

            Console.WriteLine("Paketet kunde inte hittas. ");
            return null;
        }
    }
}

    //metod för att lägga till paket
    //Metod för att ta bort paket 
    //Metod för att hitta paket i dictinary 

  


