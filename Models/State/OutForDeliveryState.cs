using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models.State
{
    public class OutForDeliveryState : IParcelState
    {
        public string StateText => "[Ute för leverans] Paketet är på väg till ombudet/upphämtning";

        public void Handle(ParcelStatus parcelStatus)
        {
            parcelStatus.State = new DeliveredState();
        }
    }
}
