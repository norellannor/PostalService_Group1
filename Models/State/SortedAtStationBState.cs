using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models.State
{
    public class SortedAtStationBState : IParcelState
    {
        public string StateText => "[Sorterat] Paketet är sorterat på Sortering B.";

        public void Handle(ParcelStatus parcelStatus)
        {
            parcelStatus.State = new OutForDeliveryState();
        }
    }
}
