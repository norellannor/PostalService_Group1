using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models.State
{
    public class SortedAtStationAState : IParcelState
    {
        public string StateText => "[Sorterat] Paketet är sorterat i Örebro.";

        public void Handle(ParcelStatus parcelStatus)
        {
            parcelStatus.State = new InTransportState();
        }
    }
}
