using Microsoft.Win32;
using PostalService.Models.ShippingStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostalService.Models.PostalCheckPoints;
using System.Xml.Serialization;

namespace PostalService.Models
{
    public class DemoClass
    {
        public static void Run()
        {


            //Address addressReciver = new Address("Ängsvägen", "78542", "Mockfjärd");
            //Address addressSender = new Address("Mossgatan", "77130", "Ludvika");

            //Customer reciver = new Customer("Emelie Lind", addressReciver);
            //Customer sender = new Customer("Erika Lind", addressSender);

            //Address addressReciver2 = new Address("Storgatan", "22220", "Lund");
            //Address addressSender2 = new Address("Lingonvägen", "77130", "Ludvika");


            //Customer reciver2 = new Customer("Lisa Andersson", addressReciver2);
            //Customer sender2 = new Customer(" Bengt Karlsson", addressSender2);

            //IShippingStrategy shippingStrategy = new StandardShipping();
            //IShippingStrategy shippingStrategy2 = new ExpressShipping();

            //Parcel parcel = new Parcel(150m, sender, reciver, shippingStrategy);
            ////Parcel parcel2 = new Parcel(1m, sender2, reciver2, shippingStrategy2);


            //ParcelRegistry registry = new ParcelRegistry();
            //registry.AddParcel(parcel);
            

            ////ParcelRegistry registry = new ParcelRegistry();   // håller alla paket
            ////parcelCreator creator = new ParcelCreator();      // frågar kunden och skapar paket

            //////Parcel parcel = creator.ConfirmCreatedParcel();   // skapa + bekräfta
            //////registry.AddParcel(parcel);
            ////// spara i dictionaryn

            ////TESTPAKET 
            //Parcel economyParcel = new Parcel(5m, sender, reciver, new EconomyShipping());
            //Parcel standardParcel = new Parcel(3m, sender2, reciver2, new StandardShipping());
            //Parcel expressParcel = new Parcel(1m, sender, reciver2, new ExpressShipping());

            //Parcel parcel = new Parcel(150m, sender, reciver, shippingStrategy);
            //Parcel parcel2 = new Parcel(1m, sender2, reciver2, shippingStrategy2);

            //TEST LÄGGER TILL DE I DICTIONARY

            //registry.AddParcel(economyParcel);    // 1006
            //registry.AddParcel(standardParcel);   // 1007
            //registry.AddParcel(expressParcel);    // 1008
            //registry.AddParcel(parcel);            
        }

        public static void ClearConsole() 
        { 
            Console.Clear();

        }
            
    }
}
