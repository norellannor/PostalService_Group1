using Microsoft.Win32;
using PostalService.Models.ShippingStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //Parcel parcel2 = new Parcel(1m, sender2, reciver2, shippingStrategy2);


            //ParcelRegistry registry = new ParcelRegistry();
            //registry.AddParcel(parcel);
            //registry.AddParcel(parcel2);


            //Console.WriteLine(parcel);
            //Console.WriteLine("...............");
            //Console.WriteLine(parcel2);

            //UserInput input = new UserInput();
            //input.ReadString("Ange ditt namn:");

            ParcelCreator parcel = new ParcelCreator();
            Parcel parcelTest = parcel.CreateParcel();



            //ParcelRegistry registry = new ParcelRegistry();
            //registry.AddParcel(parcelTest);
            //Console.WriteLine(parcelTest);

            //Console.WriteLine("Sök på ett paket");
            //int parcelSearch = Int32.Parse(Console.ReadLine());

            //registry.FindParcelById(parcelSearch);
        }
    }
}
