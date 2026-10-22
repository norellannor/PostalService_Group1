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

        //Metod för att lägga till ett paket, samt generar en key, försändelseid
        public int AddParcel(Parcel parcel)
        {

            int id = nextId;   // ta nuvarande värde
            nextId++;          // öka till nästa gång
            parcel.AssignId(id);

            parcelsInSystem.Add(id, parcel);

            return id;
        }


        //Skapa en emetod för att kolla ett paket 
    }
}

    //metod för att lägga till paket
    //Metod för att ta bort paket 
    //Metod för att hitta paket i dictinary 

  


