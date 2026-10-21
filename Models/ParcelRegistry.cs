using System;
using System.Collections.Generic;
using System.Text;

namespace PostalService
{
    public class ParcelRegistry
    {

        //private Parcel Parcel { get; set; }

        //public ParcelRegistry(int id, Parcel parcel)
        //{

        //    Parcel = parcel;

        //}

        //Dictionary som hanterar paketet. Key = försändelseId och Value = paketet 
        private readonly Dictionary<int, Parcel> parcelsInSystem = new Dictionary<int, Parcel>();


        public void AddParcel(int id, Parcel parcel)
        {

            parcelsInSystem.Add(id,parcel);
        }
        
    }
}

    //metod för att lägga till paket
    //Metod för att ta bort paket 
    //Metod för att hitta paket i dictinary 

  


